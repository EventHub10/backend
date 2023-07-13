using backend.Core;
using backend.Core.Repository;
using backend.Models;
using backend.Services.UserServices.Dto;

namespace backend.Services.UserServices
{
    public class UserService
    {

        private readonly IRepository<User> _userRepository;
        private readonly Token _tokenService;

        public UserService(IRepository<User> userRepository, Token tokenService) 
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }


        public async Task<User> GetById(Guid id, CancellationToken cancellationToken)
        {
            var user = (await _userRepository.GetById(id));

            if (user == null)
                throw new ArgumentNullException(nameof(user));

            return user;
        }

        public async Task<User> Insert(UserDto dto, CancellationToken cancellationToken) 
        {
            var emailIssetted = await _userRepository.ExistsAny(t => t.Email == dto.Email);
            if (emailIssetted)
            {
                throw new ArgumentException("E-mail já cadastrado");
            }

            var user = new User 
            {
                Email = dto.Email,
                Name = dto.Name,    
                Password = dto.Password,    
                Photo = dto.Photo   
            };

            var result = await _userRepository.Create(user);
            await _userRepository.SaveChanges(cancellationToken);
            return result;
        }

        public async Task<User> Update(UserDto dto, CancellationToken cancellationToken)
        {
            var emailIssetted = await _userRepository.ExistsAny(t => t.Email == dto.Email && t.Id != dto.Id);
            if (emailIssetted)
            {
                throw new ArgumentException("E-mail já cadastrado");
            }

            if (dto.Id == null)
                throw new ArgumentNullException(nameof(dto));   

            var user = await _userRepository.GetById(dto.Id.Value);

            if(user == null)
                throw new ArgumentNullException(nameof(user));

            user.Name = dto.Name;   
            user.Password = dto.Password;
            user.Photo = dto.Photo; 
            user.Email = dto.Email; 

            await _userRepository.SaveChanges(cancellationToken);
            return user;
        }

        public async Task<User> Delete(Guid id, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetById(id);

            if (user == null)
                throw new ArgumentNullException(nameof(user));

            _userRepository.Delete(user);
            await _userRepository.SaveChanges(cancellationToken);
            return user;
        }

        public async Task<dynamic> Login(string email, string password, CancellationToken cancellationToken)
        {
            var user = (await _userRepository.GetWithCondition(t => t.Email == email && t.Password == password)).FirstOrDefault();

            if (user == null)
                throw new ArgumentNullException(nameof(user));
            

            var token = _tokenService.GenerateToken(user);

            var result = new
            {
                token,
                UserId = user.Id
            };

            return result;
        }





    }
}
