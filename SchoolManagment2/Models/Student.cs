using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SchoolManagment2.Models
{
    public class Student
    {
        [Key]
        public int S_Id { get; set; }

        [Display(Name = "Student Name")]
        public string S_Name { get; set; }

      
        public int T_Id { get; set; }

        public int B_Id { get; set; }
        public int C_Id { get; set; }



    }
}
