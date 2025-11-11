using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ValidatonApi
{
    public delegate bool ValidateFieldDel(string fieldName);
    public delegate bool StringLengthValidDel(string fieldName, int min, int max);
    public delegate bool DateValidDel(string fieldName, out DateTime validDateTime);
    public delegate bool PatternMatchDel(string fieldName, string pattern);
    public delegate bool CompareFieldValidDel(string fieldName, string FieldValCompare);
    public class CommonFieldValidatorFunctions
    {
        private static ValidateFieldDel _requiredValidateFieldDel = null;
        private static StringLengthValidDel _requiredStringLengthValidDel = null;
        private static DateValidDel _requiredDateValidDel = null;
        private static PatternMatchDel _requiredPatternMatchDel = null;
        private static CompareFieldValidDel _requiredCompareFieldValidDel = null;

        public static ValidateFieldDel RequiredValidateFieldDel
        {
            get
            {
                return _requiredValidateFieldDel ??= new ValidateFieldDel(RequiredValidateField);
            }
        }

        public static StringLengthValidDel RequiredStringLengthValidDel
        {
            get
            {
                return _requiredStringLengthValidDel ??= new StringLengthValidDel(StringFieldLengthValid);
            }
        }
        public static DateValidDel RequiredDateValidDel
        {
            get
            {
                return _requiredDateValidDel ??= new DateValidDel(DateFieldValid);
            }
        }
        public static PatternMatchDel RequiredPatternMatchDel
        {
            get
            {
                return _requiredPatternMatchDel ??= new PatternMatchDel(FieldPatternValid);
            }
        }
        public static CompareFieldValidDel RequiredCompareFieldValidDel
        {
            get
            {
                return _requiredCompareFieldValidDel ??= new CompareFieldValidDel(FieldComparisonValid);
            }
        }
        private static bool RequiredValidateField(string fieldName) =>
         !string.IsNullOrWhiteSpace(fieldName);

        private static bool DateFieldValid(string fieldName, out DateTime validDateTime)
            => DateTime.TryParse(fieldName, out validDateTime);

        private static bool FieldPatternValid(string fieldName, string reqularExpressionPattern)
        {
            Regex model = new Regex(reqularExpressionPattern);

            return model.IsMatch(fieldName);
        }

        private static bool FieldComparisonValid(string field1, string field2)
            => field1.Equals(field2, StringComparison.OrdinalIgnoreCase);

        private static bool StringFieldLengthValid(string fieldVal, int min, int max)
        => fieldVal.Length >= min && fieldVal.Length <= max;
    }


}
