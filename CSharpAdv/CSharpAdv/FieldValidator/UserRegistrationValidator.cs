using System.Runtime.InteropServices;
using ValidatonApi;

namespace CSharpAdv.FieldValidator
{
    public class UserRegistrationValidator:IFieldValidator
    {
        private const int First_Name_Min_Length = 2;
        private const int First_Name_Max_Length = 100;
        private const int Last_Name_Min_Length = 2;
        private const int Last_Name_Max_Length = 100;

        delegate bool EmailExistsDel(string emailAddress);

        private FieldValidatorDel _fieldValidatorDel = null;

        private ValidateFieldDel _requiredValidateFieldDel = null;
        private StringLengthValidDel _requiredStringLengthValidDel = null;
        private DateValidDel _requiredDateValidDel = null;
        private PatternMatchDel _requiredPatternMatchDel = null;
        private CompareFieldValidDel _requiredCompareFieldValidDel = null;

        private EmailExistsDel _emailExistsDel = null;

        private string[] _fieldArray = null;

        public void InitialiseValidatorDelegates()
        {
            _fieldValidatorDel = new FieldValidatorDel(ValidField);

            _requiredValidateFieldDel = CommonFieldValidatorFunctions.RequiredValidateFieldDel;
            _requiredStringLengthValidDel = CommonFieldValidatorFunctions.RequiredStringLengthValidDel;
            _requiredDateValidDel= CommonFieldValidatorFunctions.RequiredDateValidDel;
            _requiredPatternMatchDel= CommonFieldValidatorFunctions.RequiredPatternMatchDel;
            _requiredCompareFieldValidDel = CommonFieldValidatorFunctions.RequiredCompareFieldValidDel;
        }

        public string[] FieldArray
        {
            get
            {
                if (_fieldArray is null)
                {
                    _fieldArray = new string[Enum.GetValues(typeof(FieldConstant.UserRegistrationField)).Length];
                }

                return _fieldArray;
            }
        }

        public FieldValidatorDel validatorDel { get; }

        private bool ValidField(int fieldIndex, string fieldValue, string[] fieldArray, out string fieldInvalidMessage)
        {
            fieldInvalidMessage = "";
            FieldConstant.UserRegistrationField userRegistrationField = (FieldConstant.UserRegistrationField)(fieldIndex);
            switch(userRegistrationField)
            {
                case FieldConstant.UserRegistrationField.EmailAddress:
                    fieldInvalidMessage = (!_requiredValidateFieldDel(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldConstant.UserRegistrationField), userRegistrationField)}{Environment.NewLine}" : "";
                    fieldInvalidMessage = (fieldInvalidMessage == "" && !_requiredPatternMatchDel(fieldValue, CommonRegularExpressionValidationPatterns.Email_Address_RegEx_Pattern)) ? $"You must enter a valid email address{Environment.NewLine}" : fieldInvalidMessage;
                    fieldInvalidMessage = (fieldInvalidMessage == "" && _emailExistsDel(fieldValue)) ? $"This email address already exists. Please try again{Environment.NewLine}" : fieldInvalidMessage;

                    break;
                case FieldConstant.UserRegistrationField.FirstName:
                    fieldInvalidMessage = (!_requiredValidateFieldDel(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldConstant.UserRegistrationField), userRegistrationField)}{Environment.NewLine}" : "";
                    fieldInvalidMessage = (fieldInvalidMessage == "" && !_requiredStringLengthValidDel(fieldValue, 2, 25)) ? $"The length for field: {Enum.GetName(typeof(FieldConstant.UserRegistrationField), userRegistrationField)} must be between 2 and 25{Environment.NewLine}" : fieldInvalidMessage;
                    break;
                case FieldConstant.UserRegistrationField.LastName:
                    fieldInvalidMessage = (!_requiredValidateFieldDel(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldConstant.UserRegistrationField), userRegistrationField)}{Environment.NewLine}" : "";
                    fieldInvalidMessage = (fieldInvalidMessage == "" && !_requiredStringLengthValidDel(fieldValue, 2, 25)) ? $"The length for field: {Enum.GetName(typeof(FieldConstant.UserRegistrationField), userRegistrationField)} must be between 2 and 25{Environment.NewLine}" : fieldInvalidMessage;
                    break;
                case FieldConstant.UserRegistrationField.Password:
                    fieldInvalidMessage = (!_requiredValidateFieldDel(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldConstant.UserRegistrationField), userRegistrationField)}{Environment.NewLine}" : "";
                    fieldInvalidMessage = (fieldInvalidMessage == "" && !_requiredPatternMatchDel(fieldValue, CommonRegularExpressionValidationPatterns.Strong_Password_RegEx_Pattern)) ? $"Your password must contain at least 1 small-case letter, 1 capital letter, 1 special character and the length should be between 6 - 10 characters{Environment.NewLine}" : fieldInvalidMessage;
                    break;
                case FieldConstant.UserRegistrationField.PasswordCompare:
                    fieldInvalidMessage = (!_requiredValidateFieldDel(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldConstant.UserRegistrationField), userRegistrationField)}{Environment.NewLine}" : "";
                    fieldInvalidMessage = (fieldInvalidMessage == "" && !_requiredCompareFieldValidDel(fieldValue, fieldArray[(int)FieldConstant.UserRegistrationField.Password])) ? $"Your entry did not match your password{Environment.NewLine}" : fieldInvalidMessage;
                    break;
                case FieldConstant.UserRegistrationField.DateOfBirth:
                    fieldInvalidMessage = (!_requiredValidateFieldDel(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldConstant.UserRegistrationField), userRegistrationField)}{Environment.NewLine}" : "";
                    fieldInvalidMessage = (fieldInvalidMessage == "" && !_requiredDateValidDel(fieldValue, out DateTime validDateTime)) ? $"You did not enter a valid date" : fieldInvalidMessage;
                    break;
                case FieldConstant.UserRegistrationField.PhoneNumber:
                    fieldInvalidMessage = (!_requiredValidateFieldDel(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldConstant.UserRegistrationField), userRegistrationField)}{Environment.NewLine}" : "";
                    fieldInvalidMessage = (fieldInvalidMessage == "" && !_requiredPatternMatchDel(fieldValue, CommonRegularExpressionValidationPatterns.Uk_PhoneNumber_RegEx_Pattern)) ? $"You did not enter a valid UK phone number{Environment.NewLine}" : fieldInvalidMessage;
                    break;
                case FieldConstant.UserRegistrationField.AddressFirstLine:
                    fieldInvalidMessage = (!_requiredValidateFieldDel(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldConstant.UserRegistrationField), userRegistrationField)}{Environment.NewLine}" : "";
                    break;
                case FieldConstant.UserRegistrationField.AddressSecondLine:
                    fieldInvalidMessage = (!_requiredValidateFieldDel(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldConstant.UserRegistrationField), userRegistrationField)}{Environment.NewLine}" : "";
                    break;
                case FieldConstant.UserRegistrationField.AddressCity:
                    fieldInvalidMessage = (!_requiredValidateFieldDel(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldConstant.UserRegistrationField), userRegistrationField)}{Environment.NewLine}" : "";
                    break;
                case FieldConstant.UserRegistrationField.PostCode:
                    fieldInvalidMessage = (!_requiredValidateFieldDel(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldConstant.UserRegistrationField), userRegistrationField)}{Environment.NewLine}" : "";
                    fieldInvalidMessage = (fieldInvalidMessage == "" && !_requiredPatternMatchDel(fieldValue, CommonRegularExpressionValidationPatterns.Uk_Post_Code_RegEx_Pattern)) ? $"You did not enter a valid UK post code{Environment.NewLine}" : fieldInvalidMessage;
                    break;
                default:
                    throw new ArgumentException("This field does not exists");

            }
            return (fieldInvalidMessage == "");
        }
    }
}
