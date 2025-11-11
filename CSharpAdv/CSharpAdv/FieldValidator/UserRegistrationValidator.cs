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

            return (fieldInvalidMessage == "");
        }
    }
}
