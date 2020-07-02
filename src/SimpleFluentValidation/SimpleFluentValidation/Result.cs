using SimpleFluentValidation.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleFluentValidation
{
    public class Result
    {
        #region Properties

        private List<Error> _erros;
        public IReadOnlyCollection<Error> Errors => _erros;

        public bool Successfull => !_erros.Any(e => e.Level == ErrorLevel.Fatal || e.Level == ErrorLevel.Error);
        public bool HasWarning => _erros.Any(e => e.Level == ErrorLevel.Warning);

        #endregion

        #region Constructors

        public Result() => _erros = new List<Error>();
        public Result(params Error[] errors) => _erros = errors.ToList();
        public Result(IList<Error> errors) => _erros = errors.ToList();

        #endregion

        #region Methods

        public void AddError(Error error)
        {
            _erros.Add(error);
        }

        public void AddErrorRange(IEnumerable<Error> errors)
        {
            _erros.AddRange(errors);
        }

        public void RemoveError(Error error)
        {
            var errorToRemove = _erros.Find(e => e.Key == error.Key);
            _erros.Remove(errorToRemove);
        }

        public void ClearErrors() => _erros.Clear();

        public static Result Combine(IEnumerable<Result> results)
        {
            return new Result()
            {
                _erros = results.SelectMany(r => r.Errors).ToList()
            };
        }

        public static Result<T> Combine<T>(IEnumerable<Result> results, T value)
        {
            T ret = value;

            if (results.Any(r => !r.Successfull))
                ret = default(T);

            return new Result<T>(ret, results.SelectMany(r => r.Errors).ToList());

        }

        #endregion
    }

    public class Result<T> : Result
    {
        #region Properties

        public readonly T Value;

        #endregion

        #region Constructor

        public Result(T value, params Error[] errors) : base(errors)
        {
            Value = value;
        }

        public Result(T value, IList<Error> errors):base(errors)
        {
            Value = value;
        }

        #endregion

    }
}
