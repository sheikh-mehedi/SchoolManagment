using System.ComponentModel.DataAnnotations;

namespace SchoolManagment2.Models
{
    public class Book
    {
        [Key]
        public int B_Id { get; set; }

        [Display(Name = "Book Name")]
        public string B_Name{ get; set; }
    }
}
