using FluentValidation.Results;

namespace BeautySalonManage.Application.Exceptions
{
    public class ValidationsException : Exception
    {
        public List<string> Errors { get; private set; }

        public ValidationsException() : base("Han ocurrido uno o más errores de validación")
        {
            Errors = new List<string>();
        }

        public ValidationsException(IEnumerable<ValidationFailure> failures) : this()
        {
            Errors.AddRange(failures.Select(f => f.ErrorMessage));
        }
    }
}
