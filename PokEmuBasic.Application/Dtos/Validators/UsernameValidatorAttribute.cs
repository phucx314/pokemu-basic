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
    public class UsernameValidatorAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult($"{validationContext.DisplayName} is required");
            }

            var name = value.ToString();

            if (string.IsNullOrWhiteSpace(name))
            {
                return new ValidationResult($"{validationContext.DisplayName} is required");
            }

            var regex = new Regex(RegexConstants.UsernamePattern);

            if (!regex.IsMatch(name))
            {
                return new ValidationResult($"{validationContext.DisplayName} allows lowercases and numbers only");
            }

            if (name.Length < UserConstants.USERNAME_MIN_LENGTH || name.Length > UserConstants.USERNAME_MAX_LENGTH)
            {
                return new ValidationResult($"{validationContext.DisplayName} must be between {UserConstants.USERNAME_MIN_LENGTH} and {UserConstants.USERNAME_MAX_LENGTH} characters");
            }

            return ValidationResult.Success;
        }
    }
}
