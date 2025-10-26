using PokEmuBasic.Domain.Common.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PokEmuBasic.Application.Dtos.Validators
{
    public class PasswordValidatorAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
            {
                return new ValidationResult("Password is required");
            }

            var password = value.ToString();

            if (string.IsNullOrWhiteSpace(password))
            {
                return new ValidationResult("Password is required");
            }

            var regex = new Regex(RegexConstants.PasswordPattern);

            if (!regex.IsMatch(password!))
            {
                return new ValidationResult("Password must be at least 8 characters long and contain both letters and numbers");
            }

            if (password.Length < UserConstants.PASSWORD_MIN_LENGTH || password.Length > UserConstants.PASSWORD_MAX_LENGTH)
            {
                return new ValidationResult($"{validationContext.DisplayName} must be between {UserConstants.USERNAME_MIN_LENGTH} and {UserConstants.USERNAME_MAX_LENGTH} characters");
            }

            return ValidationResult.Success;
        }
    }
}
