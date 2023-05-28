using FluentValidation.Results;

namespace BeautySalonManage.Application.Common.Exceptions
{
    public class ValidationException : Exception
    {
        public List<string> Errors { get; private set; }

        public ValidationException() : base("Han ocurrido uno o más errores de validación")
        {
            Errors = new List<string>();
        }

        public ValidationException(IEnumerable<ValidationFailure> failures) : this()
        {
            Errors.AddRange(failures.Select(f => f.ErrorMessage));
        }
    }
}
