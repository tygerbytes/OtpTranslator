using System;
using System.ComponentModel.DataAnnotations;

namespace OtpTranslator.CLI
{
    [AttributeUsage(AttributeTargets.Class)]
    internal class ValidateRequiredParametersAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext context)
        {
            if (value is not Program options)
            {
                return ValidationResult.Success;
            }

            if (string.IsNullOrWhiteSpace(options.FromType))
            {
                return new ValidationResult("Missing type to translate from (e.g. Aegis, Raivo)");
            }

            if (string.IsNullOrWhiteSpace(options.ToType))
            {
                return new ValidationResult("Missing type to translate to (e.g. Aegis, Raivo");
            }

            if (string.IsNullOrWhiteSpace(options.SourcePath))
            {
                return new ValidationResult("Missing path of file to translate");
            }

            if (!File.Exists(options.SourcePath))
            {
                return new ValidationResult("File doesn't exist");
            }

            return ValidationResult.Success;
        } 
    }
}
