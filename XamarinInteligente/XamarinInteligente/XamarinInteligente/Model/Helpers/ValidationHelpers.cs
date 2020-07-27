using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace XamarinInteligente.Model.Helpers
{
    public enum ValidationType
    {
        Email,
        PhoneNumber,
        Password,
        None
    }

    public class ValidationHelpers
    {
        public static bool ValidateString(ValidationType validationType, string valueToValidate)
        {
            Regex regex = null;

            switch (validationType)
            {
                case ValidationType.Email:
                    regex = new Regex(Constants.ValidationConstants.EMAIL);
                    break;
                case ValidationType.Password:
                    regex = new Regex(Constants.ValidationConstants.PASSWORD);
                    break;
                case ValidationType.PhoneNumber:
                    regex = new Regex(Constants.ValidationConstants.PHONE);
                    break;
                case ValidationType.None:
                    return true;
                default:
                    throw new InvalidCastException("OperationType is invalid");

            }

            Match match = regex.Match(valueToValidate);
            bool isValid = match.Success;
            return isValid;
        }
    }
}
