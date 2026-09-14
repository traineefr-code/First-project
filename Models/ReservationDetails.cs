using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class ReservationDetails
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; } = "";

        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; } = "";


        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; } = "";


        [Required(ErrorMessage = "Number of guests are expected")]
        public int R_Size { get; set; }

        [Required(ErrorMessage = "Day of reservation is expected")]
        public DateOnly R_Date { get; set; }

        [Required(ErrorMessage = "Time of arrival is expected")]
        public TimeOnly R_Time { get; set; }
    }
}
