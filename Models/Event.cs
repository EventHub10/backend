﻿using backend.Core.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace backend.Models
{
    [Table("event")]
    public class Event : BaseEntity
    {
        public string Event_title { get; set;}

        public string Event_photo { get; set;}

        public DateTime Event_date { get; set;}

        public float Event_price { get; set;}
        
        public string Link_to_buy { get; set; }

        public string Location { get; set; }

        public string Description { get; set; }

        [ForeignKey(nameof(User))]
        public Guid OwnerId { get; set; }
        public virtual User Owner { get; set; }

        [NotMapped]
        public virtual ICollection<Confirmed_People> Confirmed_peoples { get; set; }
    }
}