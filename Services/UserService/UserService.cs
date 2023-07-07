using backend.Core.Repository;
using backend.Models;
using backend.Services.UserServices.Dto;

namespace backend.Services.UserServices
{
    public class UserService
    {

        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository) 
        {
            _userRepository = userRepository;
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
            if(dto.Id == null)
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





    }
}
