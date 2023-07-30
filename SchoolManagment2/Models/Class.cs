using System.ComponentModel.DataAnnotations;

namespace SchoolManagment2.Models
{
    public class Class
    {
        [Key]
        public int C_Id { get; set; }

        [Display(Name = "Class Name")]
        public string C_Name { get; set; }

        public int B_Id { get; set; }
    }
}
