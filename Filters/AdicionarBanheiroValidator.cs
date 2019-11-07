using banheiro_livre.ViewModel;
using FluentValidation;

namespace banheiro_livre.Filters
{
    public class AdicionarBanheiroValidator : AbstractValidator<AdicionarBanheiroPostRequest>
    {
        public AdicionarBanheiroValidator()
        {
            RuleFor(x => x)
                .NotEmpty().WithMessage("Parâmetros de requisição não podem ser nulo");

            RuleFor(x => x.Descricao)
                .NotEmpty().WithMessage("Descrição deve ser preenchida");
        }
    }
}