using FluentValidation;
using monitoreo.Core.DTOs.Request;
using System.Text.RegularExpressions;

namespace monitoreo.Api.Validators
{
    public class ErrorLogValidator : AbstractValidator<ErrorLogRequestDTO>
    {
        public ErrorLogValidator()
        {
            Include(new ErrorLogNameIsSpecified());
        }

        //private bool HasValidPassword(string pw)
        //{
        //    var lowercase = new Regex("[a-z]+");
        //    var uppercase = new Regex("[A-Z]+");
        //    var digit = new Regex("(\\d)+");
        //    var symbol = new Regex("(\\W)+");

        //    return (lowercase.IsMatch(pw) && uppercase.IsMatch(pw) && digit.IsMatch(pw) && symbol.IsMatch(pw));
        //}
    }

    public class ErrorLogNameIsSpecified : AbstractValidator<ErrorLogRequestDTO>
    {
        //public ErrorLogNameIsSpecified()
        //{
        //    RuleFor(user => user.FirstName)
        //        .Cascade(CascadeMode.Stop)
        //        .NotEmpty()
        //        .WithMessage("No ha indicado el nombre.")
        //        .Length(5, 50)
        //        .WithMessage("{PropertyName} tiene {TotalLength} letras. Debe tener una longitud entre {MinLength} y {MaxLength} letras.");
        //}
    }

   
}