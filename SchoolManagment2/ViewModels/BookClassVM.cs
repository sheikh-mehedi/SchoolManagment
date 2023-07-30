using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SchoolManagment2.ViewModels
{
    public class BookClassVM
    {
        public int C_Id { get; set; }

        [Display(Name = "Class Name")]
        public string C_Name { get; set; }

        public int B_Id { get; set; }

        [Display(Name = "Book Name")]
        public string B_Name { get; set; }
    }
}
