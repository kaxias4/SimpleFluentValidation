using SimpleFluentValidation.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleFluentValidation
{
    public class Error
    {
        #region Properties

        public string Key { get; private set; }
        public string Message { get; private set; }
        public ErrorLevel Level { get; private set; }

        #endregion

        #region Constructors

        public Error(string key, string message, ErrorLevel level)
        {
            Key = key;
            Message = message;
            Level = level;
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            return $"{Level.Name}: {Message}";
        }

        #endregion
    }
}
