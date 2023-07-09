using backend.Core.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    [Table("event_table")]
    public class Event : BaseEntity
    {
        public int Event_id { get; set; }

        public int Owner_id { get; set; }

        public string Event_title { get; set;}

        public string Event_photo { get; set;}

        public DateTime Event_date { get; set;}

        public float Event_price { get; set;}
        
        public string Link_to_buy { get; set; }

        public string Location { get; set; }

        public string Description { get; set; }

        [ForeignKey(nameof(User))]

        public Guid UserID { get; set; }

        public virtual User User { get; set; }

        //public virtual
        //ICollection<table_confirmation>confirmed_peoples { get; set; }
    }
}