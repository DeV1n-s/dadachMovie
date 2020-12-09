using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace dadachMovie.Validations
{
    public class FileSizeValidator : ValidationAttribute
    {
        private readonly int maxFileSizeInMbs;

        public FileSizeValidator(int maxFileSizeInMbs)
        {
            this.maxFileSizeInMbs = maxFileSizeInMbs;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            IFormFile formFile = value as IFormFile;
            if (formFile == null)
            {
                return ValidationResult.Success;
            }
            
            if (formFile.Length > maxFileSizeInMbs * 1024 * 1024)
            {
                return new ValidationResult($"File size cannot be bigger than {maxFileSizeInMbs} mb.");
            }
            return ValidationResult.Success;
        }
    }
}