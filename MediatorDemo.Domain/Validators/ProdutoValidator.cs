using FluentValidation;

namespace MediatorDemo.Domain.Validators;

public class ProdutoValidator : AbstractValidator<Produto>
{
	public ProdutoValidator()
	{
		RuleFor(x => x.CodigoBarras).NotNull().WithMessage("Campo não pode ser nulo").NotEmpty().WithMessage("Campo obrigatório");
        RuleFor(x => x.NomeProduto).NotNull().WithMessage("Campo obrigatório");
		RuleFor(x => x.Preco).NotNull().WithMessage("Não pode ser nulo").GreaterThan(0).WithMessage("Informe um valor maior que 0");
	}
}
