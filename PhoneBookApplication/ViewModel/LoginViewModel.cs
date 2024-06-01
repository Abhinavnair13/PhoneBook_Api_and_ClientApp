﻿using System.ComponentModel.DataAnnotations;

namespace PhoneBookApplication.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "UserName is Required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }






    }
}
