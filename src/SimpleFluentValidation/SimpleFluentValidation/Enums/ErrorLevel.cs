using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleFluentValidation.Enums
{
    public class ErrorLevel : Enumeration
    {
        public static readonly ErrorLevel Warning = new ErrorLevel(1, "Warning");
        public static readonly ErrorLevel Error = new ErrorLevel(2, "Error");
        public static readonly ErrorLevel Fatal = new ErrorLevel(3, "Fatal");

        public ErrorLevel(int id, string name)
            : base(id, name)
        {
        }
    }
}
