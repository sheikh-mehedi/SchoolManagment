using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SchoolManagment2.ViewModels
{
    public class TeacherClassVM
    {
        public int T_Id { get; set; }

        [Display(Name = "Teacher Name")]
        public string T_Name { get; set; }

        public int C_Id { get; set; }

        [Display(Name = "Class Name")]
        public string C_Name { get; set; }
    }
}
