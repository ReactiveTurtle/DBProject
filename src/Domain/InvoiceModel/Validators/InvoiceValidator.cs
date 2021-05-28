using FluentValidation;
using Toolkit.Validation;

namespace Domain.InvoiceModel
{
    public partial class Invoice
    {
        public static readonly int NameMinLength = 6;
        public static readonly int NameMaxLength = 256;

        internal class InvoiceValidator : AbstractValidator<string>
        {
            public InvoiceValidator( string fieldName )
            {
                RuleFor( name => name )
                    .Length( NameMinLength, NameMaxLength )
                    .WithMessage( ValidationMessage.LengthMustBeWithinRange(
                        fieldName, NameMinLength, NameMaxLength ) );
            }
        }
    }
}