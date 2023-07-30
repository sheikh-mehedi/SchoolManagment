using System.ComponentModel.DataAnnotations;

namespace SchoolManagment2.ViewModels
{
    public class StudentTeacherVM
    {
        public int S_Id { get; set; }

        [Display(Name = "Student Name")]
        public string S_Name { get; set; } 

        public int T_Id { get; set; }

        [Display(Name ="Teacher Name")]
        public string T_Name { get; set;}

        public int B_Id { get; set; }

        [Display(Name = "Book Name")]
        public string B_Name { get; set; }

        public int C_Id { get; set; }

        [Display(Name = "Class Name")]
        public string C_Name { get; set; }
    }
}
