using System.ComponentModel.DataAnnotations;

namespace WebAPI.Domain.Attributes;

public class DivBySevenAttribute : ValidationAttribute
{
    public DivBySevenAttribute() : base("{0} não é divisível por 7")
    { }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        int valor = (int)value;
        bool valido = valor % 7 == 0;
        if (valido)
            return null;
        return new ValidationResult(base.FormatErrorMessage(validationContext.MemberName)
            , new string[] { validationContext.MemberName });
    }

    // A data annotation customizada será [DivBySeven]
}
