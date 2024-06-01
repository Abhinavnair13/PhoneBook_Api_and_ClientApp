using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace PhoneBookApplication.ViewModel
{
    public class PhoneBookViewModel
    {
        [Key]
        [DisplayName("Phone id")]
        public int PhoneId { get; set; }
        [Required(ErrorMessage = "First name is required")]
        [StringLength(15)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(15)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Company name is required")]
        [StringLength(15)]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [StringLength(35)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Contact number is required")]
        [StringLength(15)]
        public string ContactNumber { get; set; }
        [Required(ErrorMessage = "File  is required")]

        public IFormFile File { get; set; }

    }
}
