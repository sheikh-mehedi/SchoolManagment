using System.ComponentModel.DataAnnotations;

namespace SchoolManagment2.Models
{
    public class Mehedi
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string TypeCode { get; set; }

    }
}
