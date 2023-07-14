using backend.Core.Repository;
using backend.Models;
using backend.Services.EventService.Dto;
using Microsoft.AspNetCore.Mvc;

namespace backend.Services.EventService
{
    public class EventService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Event> _eventRepository;
        private readonly IRepository<Confirmed_People> _confirmRepository;
        private readonly IHttpContextAccessor _accessor;


        public EventService(IRepository<Event> eventRepository, IRepository<Confirmed_People> confirmRepository, 
            IRepository<User> userRepository, IHttpContextAccessor accessor)
        {
            _eventRepository = eventRepository;
            _confirmRepository = confirmRepository;
            _userRepository = userRepository;   
            _accessor = accessor;   
        }


        public async Task<Event> GetById(Guid id, CancellationToken cancellationToken)
        {
            var Event = (await _eventRepository.GetById(id));
            

            if (Event == null)
                throw new ArgumentNullException(nameof(Event));

            var confirmedPeoples = await _confirmRepository.GetWithCondition(x => x.EventID == Event.Id);
            Event.Confirmed_peoples = confirmedPeoples.ToList();

            return Event;
        }

        public async Task<IEnumerable<Event>> GetAll(CancellationToken cancellationToken)
        {
            var Event = await _eventRepository.GetAll(cancellationToken);

            if (Event == null)
                throw new ArgumentNullException(nameof(Event));

            return Event;
        }

        public async Task<Event> Insert(EventDto dto, CancellationToken cancellationToken)
        {
            var Event = new Event
            {
                Description = dto.Description,   
                Event_date = dto.Event_date.ToUniversalTime(), 
                Event_price  = dto.Event_price,  
                Event_photo = dto.Event_photo,
                Event_title = dto.Event_title,   
                Link_to_buy = dto.Link_to_buy,
                Location = dto.Location,
                OwnerId = dto.OwnerId.Value
            };

            var result = await _eventRepository.Create(Event);
            await _eventRepository.SaveChanges(cancellationToken);
            return result;
        }

        public async Task<Event> Update(EventDto dto, CancellationToken cancellationToken)
        {

            var userId = Guid.Parse(_accessor.HttpContext.User.Claims.FirstOrDefault(item => item.Type == "userId").Value);

            if (dto.Id == null)
                throw new ArgumentNullException(nameof(dto));

            var Event = await _eventRepository.GetById(dto.Id.Value);

            if (Event == null)
                throw new ArgumentNullException(nameof(Event));

            if (userId != Event.OwnerId) 
            {
                throw new ArgumentException("Não é possível editar esse evento");
            }

            Event.Event_date = dto.Event_date.ToUniversalTime();
            Event.Event_price = dto.Event_price;    
            Event.Description = dto.Description;
            Event.Event_photo = dto.Event_photo;
            Event.Event_title = dto.Event_title;    
            Event.Location = dto.Location;  
            Event.Link_to_buy = dto.Link_to_buy;

            await _eventRepository.SaveChanges(cancellationToken);
            return Event;
        }

        public async Task<Event> Delete(Guid id, CancellationToken cancellationToken)
        {
            var Event = await _eventRepository.GetById(id);
            var userId = Guid.Parse(_accessor.HttpContext.User.Claims.FirstOrDefault(item => item.Type == "userId").Value);

            if (Event == null)
                throw new ArgumentNullException(nameof(Event));

            if (userId != Event.OwnerId) 
            {
                throw new ArgumentException("Não é possível excluir esse evento");
            }

            _eventRepository.Delete(Event);
            await _eventRepository.SaveChanges(cancellationToken);
            return Event;
        }

        public async Task<bool> ConfirmPresence(Guid userId, Guid eventId, 
            CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetById(userId);
            var Event = await _eventRepository.GetById(eventId);
            var alreadyConfirmed = (await _confirmRepository.ExistsAny(x => x.UserID == userId && x.EventID == eventId));

            if (user == null)
                throw new ArgumentNullException(nameof(user));

            if (Event == null)
                throw new ArgumentNullException(nameof(Event));

            if (alreadyConfirmed) 
            {
                throw new ArgumentException("Você já confirmou presença nesse evento.");
            }

            var confirm = new Confirmed_People
            {
                EventID = eventId,
                UserID = userId,
            };

            await _confirmRepository.Create(confirm);
            await _confirmRepository.SaveChanges(cancellationToken);

            return true;
        }
    }
}
