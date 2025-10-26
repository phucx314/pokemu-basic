using PokEmuBasic.Application.Dtos.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokEmuBasic.Application.Dtos.Requests
{
    public class RegisterNewUserRequest
    {
        [FullNameValidator]
        public string FullName { get; set; } = default!;

        [UsernameValidator]
        public string Username { get; set; } = default!;

        [PasswordValidator]
        public string Password { get; set; } = default!;

        [Required]
        [Compare(nameof(Password), ErrorMessage = "Password does not match")]
        public string ConfirmPassword { get; set; } = default!;
    }
}
