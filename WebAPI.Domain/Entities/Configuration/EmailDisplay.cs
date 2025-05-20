using FastPackForShare.Constants;
using FastPackForShare.Default;
using FastPackForShare.Extensions;
using MimeKit;

namespace WebAPI.Domain.Entities.Configuration;

public class EmailDisplay : BaseEntityModel
{
    public string Title { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public MessagePriority MessagePriority { get; set; }
    public bool HasAttachment { get; set; }
    public virtual EmailTemplate EmailTemplates { get; set; }
    public long EmailTemplateId { get; set; }

    protected override void CreateEntityIsValid()
    {
        BaseDomainException.WhenIsInvalid(GuardClauseExtension.IsNullOrWhiteSpace(Title), ConstantValidation.REQUIRED);
    }

    protected override void UpdateEntityIsValid()
    {
        BaseDomainException.WhenIsInvalid(GuardClauseExtension.IsNullOrWhiteSpace(Title), ConstantValidation.REQUIRED);
    }
}
