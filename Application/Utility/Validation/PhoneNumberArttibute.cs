using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Application.Utility.Validation
{
    public class PhoneNumberArttibute : ValidationAttribute
    {
        private readonly string _phoneNumber;

        public PhoneNumberArttibute(string phoneNumber)
        {
            _phoneNumber = phoneNumber;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var regex = new Regex("\\(?\\d{3}\\)?-? *\\d{3}-? *-?\\d{4}");
            if(value!=null)
            {
                if (!regex.IsMatch(value.ToString()))
                {
                    return new ValidationResult($"Phone number {value.ToString()} is invalid.");
                }
            }
            return ValidationResult.Success;
        }
    }
}
