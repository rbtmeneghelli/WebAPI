using WebAPI.Domain.Generic;
using FluentValidation;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace WebAPI.Application.Generic;

public abstract class GenericService
{
    private readonly INotificationMessageService _notificationMessageService;

    protected GenericService(INotificationMessageService notificationMessageService)
    {
        _notificationMessageService = notificationMessageService;
    }

    protected void Notify(ValidationResult validationResult)
    {
        foreach (var error in validationResult.Errors)
        {
            Notify(error.ErrorMessage);
        }
    }

    protected void Notify(string message)
    {
        _notificationMessageService.Handle(new NotificationMessage(message));
    }

    protected bool ExecuteValidation<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : GenericEntity
    {
        var validator = validacao.Validate(entidade);

        if (validator.IsValid) return true;

        Notify(validator);

        return false;
    }
}

