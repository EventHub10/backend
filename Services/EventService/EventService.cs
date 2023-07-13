using backend.Core.Repository;
using backend.Models;
using backend.Services.EventService.Dto;

namespace backend.Services.EventService
{
    public class EventService
    {
        private readonly IRepository<Event> _eventRepository;

        public EventService(IRepository<Event> eventRepository)
        {
            _eventRepository = eventRepository;
        }


        public async Task<Event> GetById(Guid id, CancellationToken cancellationToken)
        {
            var Event = (await _eventRepository.GetById(id));

            if (Event == null)
                throw new ArgumentNullException(nameof(Event));

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
            if (dto.Id == null)
                throw new ArgumentNullException(nameof(dto));

            var Event = await _eventRepository.GetById(dto.Id.Value);

            if (Event == null)
                throw new ArgumentNullException(nameof(Event));

            Event.Event_date = dto.Event_date;
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

            if (Event == null)
                throw new ArgumentNullException(nameof(Event));

            _eventRepository.Delete(Event);
            await _eventRepository.SaveChanges(cancellationToken);
            return Event;
        }
    }
}
