using System.ComponentModel.DataAnnotations;

namespace SchoolManagment2.Models
{
    public class Teacher
    {
        [Key]
        public int T_Id { get; set; }

        [Display(Name = "Teacher Name")]
        public string T_Name { get; set; }

        public int C_Id { get; set; }
       
        
    }
}
