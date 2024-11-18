using System.ComponentModel.DataAnnotations;

namespace AppDev.API.Models.EnumValidation
{
    public class ValidEnumAttribute : ValidationAttribute
    {
        private readonly Type _enumType;

        public ValidEnumAttribute(Type enumType)
        {
            if (enumType == null || !enumType.IsEnum) { 
                throw new ArgumentException("EnumType must be an enum", nameof(enumType));
            }

            this._enumType = enumType;
        }
        public override bool IsValid(object value)
        {
            if(value == null) return false;
            return Enum.IsDefined(_enumType, value);
        }
    }
}
