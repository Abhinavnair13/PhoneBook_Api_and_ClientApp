using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PhoneBookApplication.Models
{
    public class PhoneBook
    {

        [Key]
        [DisplayName("Phone id")]
        public int PhoneId { get; set; }
        [StringLength(15)]
        public string FirstName { get; set; }

        [StringLength(15)]
        public string LastName { get; set; }  
        [StringLength(15)]
        public string CompanyName { get; set; }

        [StringLength(35)]
        public string Email { get; set; }

        [StringLength(15)]
        public string ContactNumber { get; set; }
        public string FileName { get; set; }


    }
}
