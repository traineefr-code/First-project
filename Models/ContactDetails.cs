using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class ContactDetails
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The first name is required")]
        public string FirstName { get; set; } = "";

        [Required(ErrorMessage = "The last name is required")]
        public string LastName { get; set; } = "";


        [Required(ErrorMessage = "The email is required")]
        [EmailAddress]
        public string Email { get; set; } = "";


        [Required(ErrorMessage = "The message is required")]
        public string Message { get; set; } = "";
    }
}
