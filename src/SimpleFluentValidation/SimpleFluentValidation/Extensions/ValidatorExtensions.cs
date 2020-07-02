using SimpleFluentValidation.Enums;
using System;
using System.Collections.Generic;
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
    }
}
