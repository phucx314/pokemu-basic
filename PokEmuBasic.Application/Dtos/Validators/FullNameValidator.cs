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
    public class FullNameValidatorAttribute : ValidationAttribute
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

            var regex = new Regex(RegexConstants.NamePattern);

            if (!regex.IsMatch(name))
            {
                return new ValidationResult($"{validationContext.DisplayName} only allows letters, numbers, apostrophe (')");
            }

            if (name.Length < UserConstants.FULLNAME_MIN_LENGTH || name.Length > UserConstants.FULLNAME_MAX_LENGTH)
            {
                return new ValidationResult($"{validationContext.DisplayName} must be between {UserConstants.USERNAME_MIN_LENGTH} and {UserConstants.FULLNAME_MAX_LENGTH} characters");
            }

            return ValidationResult.Success;
        }
    }
}
