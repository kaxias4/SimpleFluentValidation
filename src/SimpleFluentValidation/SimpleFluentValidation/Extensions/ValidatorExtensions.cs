using SimpleFluentValidation.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SimpleFluentValidation.Extensions
{
    public static class ValidatorExtensions
    {
        public static Validator<T> Required<T>(this Validator<T> validator, Error error = null)
        {
            if (error == null)
                error = new Error("Required", "Campo é obrigatório", ErrorLevel.Error);

            validator.AddRule(value =>
            {
                if (value is string)
                    return !string.IsNullOrEmpty(value as string);

                return value != null && !value.Equals(default(T));
            }, error);

            return validator;
        }

        public static Validator<string> MaxLength(this Validator<string> validator, int maxLength, Error error = null)
        {
            if (error == null)
                error = new Error("MaxLength", $"Valor não pode ter mais de {maxLength} caracter(es)", ErrorLevel.Error);

            validator.AddRule(value =>
            {
                if (string.IsNullOrWhiteSpace(value))
                    return true;

                return value.Length <= maxLength;

            }, error);

            return validator;
        }

        public static Validator<string> OnlyNumbers(this Validator<string> validator, Error error = null)
        {
            if(error == null)
                error = new Error("OnlyNumbers", $"Valor só pode ter números.", ErrorLevel.Error);

            validator.AddRule(value =>
            {
                if (string.IsNullOrWhiteSpace(value))
                    return true;

                foreach (char c in value)
                {
                    if (c < '0' || c > '9')
                        return false;
                }

                return true;
            }, error);

            return validator;
        }
    }
}
