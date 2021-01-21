using System.ComponentModel.DataAnnotations;

namespace dadachMovie.Validations
{
    public class ImdbIdValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return ValidationResult.Success;

            if (value.ToString().Substring(0,2) != "tt")
                return new ValidationResult("ImdbId should start with 'tt'");
            
            return ValidationResult.Success;
        }
    }
}