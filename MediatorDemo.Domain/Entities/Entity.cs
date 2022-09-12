using FluentValidation;
using FluentValidation.Results;

namespace MediatorDemo.Domain.Entities;

public abstract class Entity
{
    public Guid Id { get; protected set; }
    public DateTime Criacao { get; protected set; }
    public DateTime? UltimaAtualizacao { get; protected set; }

    public bool Valid { get; private set; }
    public bool Invalid => !Valid;
    public ValidationResult ValidationResult { get; private set; } = null!;

    public bool Validate<TModel>(TModel model, AbstractValidator<TModel> validator)
	{
		ValidationResult = validator.Validate(model);
		return Valid = ValidationResult.IsValid;
	}
}
