namespace backend.Services.EventService.Dto
{
    public class EventDto
    {
        public Guid? Id { get; set; }
        public Guid? OwnerId { get; set; }
        public string Event_title { get; set; }
        public string Event_photo { get; set; }
        public DateTime Event_date { get; set; }
        public int Event_price { get; set; }
        public string Link_to_buy { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
    }
}
