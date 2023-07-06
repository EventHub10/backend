using backend.Core.Model;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    [Table("confirmed-people_table")]
    public class Confirmed_People : BaseEntity
    {

        [ForeignKey(nameof(User))]

        public Guid UserID { get; set; }

        public virtual User User { get; set; }

        [ForeignKey(nameof(Event))]

        public Guid EventID { get; set; }

        public virtual Event Event { get; set; }
    }
}