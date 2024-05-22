﻿using System.ComponentModel.DataAnnotations;

namespace WebApplication15.ViewModels.Account
{
    public class RegisterVM
    {
        [MinLength(5)]
        [MaxLength(50)]
        public string Name { get; set; }
        [MinLength(5)]
        [MaxLength(50)]
        public string Surname { get; set; }
        [MinLength(5)]
        [MaxLength(50)]
        public string UserName { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

    }
}
