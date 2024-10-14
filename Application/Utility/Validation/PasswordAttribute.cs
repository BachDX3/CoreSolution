using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Application.Utility.Validation
{
    #region Check lowercase character 
    public class RequiredLowerCase : ValidationAttribute
    {
        public readonly string _value;
        public RequiredLowerCase(string value)
        {
            _value = value;
        }
        /// <summary>
        /// check required assword must contain at least one lowercase character  
        /// </summary>
        /// <param name="value">If value is true check required</param>
        /// <param name="validationContext">Describes the context in which a validation is being performed.</param>
        /// <returns></returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var regex = new Regex(" (?=.*[a-z])");
            if (value!=null)
            {
                if (!regex.IsMatch(value.ToString()))
                {
                    return new ValidationResult($"Password must contain at least one lowercase  character");
                }
            }
            return ValidationResult.Success;
        }

    }
    #endregion

    #region Check uppercase character
    public class RequiredUpperCase : ValidationAttribute
    {
        public readonly string _value;
        public RequiredUpperCase(string value)
        {
            _value = value;
        }

        /// <summary>
        /// Check required assword must contain at least one uppercase character  
        /// </summary>
        /// <param name="value">If value is true check required</param>
        /// <param name="validationContext">Describes the context in which a validation is being performed.</param>
        /// <returns></returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var regex = new Regex(" (?=.*[A-Z])");
            if (value!=null)
            {
                if (!regex.IsMatch(value.ToString()))
                {
                    return new ValidationResult($"Password must contain at least one uppercase character");
                }
            }
            return ValidationResult.Success;
        }

    }
    #endregion

    #region Check specical Symbol
    public class RequiredSpecicalSymbol : ValidationAttribute
    {
        public readonly string _value;
        public RequiredSpecicalSymbol(string value)
        {
            _value = value;
        }

        /// <summary>
        /// Check required password must contain at least one special symbol 
        /// </summary>
        /// <param name="value">If value is true check required</param>
        /// <param name="validationContext">Describes the context in which a validation is being performed.</param>
        /// <returns></returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var regex = new Regex("(?=.*\\W)");
            if (value!=null)
            {
                if (!regex.IsMatch(value.ToString()))
                {
                    return new ValidationResult($"Password must contain at least one special symbol");
                }
            }
            return ValidationResult.Success;
        }

    }
    #endregion

    #region Check least one number 
    public class RequiredNumber : ValidationAttribute
    {
        public readonly string _value;
        public RequiredNumber(string value)
        {
            _value = value;
        }

        /// <summary>
        /// Check required password must contain at least one number
        /// </summary>
        /// <param name="value">If value is true check required</param>
        /// <param name="validationContext">Describes the context in which a validation is being performed.</param>
        /// <returns></returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var regex = new Regex("(?=.*\\d)");
            if (value!=null)
            {
                if (!regex.IsMatch(value.ToString()))
                {
                    return new ValidationResult($"Password must contain at least one number");
                }
            }
            return ValidationResult.Success;
        }

    }
    #endregion

}
