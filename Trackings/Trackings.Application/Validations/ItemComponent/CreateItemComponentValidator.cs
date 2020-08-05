using Trackings.Application.Commands;
using Trackings.Application.Utility;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Trackings.Application.Validations
{
    public class CreateItemComponentValidator : AbstractValidator<CreateItemComponentCommand>
    {
        public CreateItemComponentValidator()
        {
            RuleFor(command => command.name)
                .NotEmpty().WithMessage(ItemComponentMessages.NAME_EMPTY)
                    .MaximumLength(50).WithMessage(ItemComponentMessages.NAME_LENGTH)
                    .Must((a, b) => ValidacionNombre(a.name)).WithMessage(ItemComponentMessages.NAME_INVALID);
        }
        public bool ValidacionNombre(string dato)
        {
            Regex regex = new Regex(@"^[a-zA-ZáéíóúÁEÍÓÚäëïöüÄËÏÖÜ ]");
            var match = regex.Match(dato);
            if (!match.Success)
            {
                return false;
            }
            return true;
        }
    }
}
