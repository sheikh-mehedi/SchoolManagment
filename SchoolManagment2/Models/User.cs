using System.ComponentModel.DataAnnotations;

namespace SchoolManagment2.Models
{
    public class User
    {
        [Key]
        public int U_Id { get; set; }

        [Display(Name = "User Name")]
        public string U_Name { get; set;}

        [Display(Name = "User Password")]
        public string U_Password { get; set;}
    }
}
