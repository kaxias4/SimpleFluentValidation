using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleFluentValidation
{
    public class Validator<T>
    {
        #region Properties

        private readonly T _value;
        private readonly HashSet<Error> _validationErrors;

        #endregion

        #region Constructor

        public Validator(T value)
        {
            _value = value;
            _validationErrors = new HashSet<Error>();
        }

        #endregion

        #region Methods

        public Result<T> GetResult() => new Result<T>(_value, _validationErrors.ToList());

        public Validator<T> AddRule(Func<T, bool> rule, Error error)
        {
            if (!rule(_value))
                _validationErrors.Add(error);

            return this;
        }

        #endregion
    }
}
