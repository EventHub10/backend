using backend.Core.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    [Table("sample_table")]
    public class Sample : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
