using FluentValidation;

namespace PoC_RfcDomainException.ApiHost.Models.Requests.Validators
{
    public class CreateCarValidator : AbstractValidator<CreateCar>
    {
        public CreateCarValidator()
        {
            RuleFor(request => request.Brand).NotEmpty();
            RuleFor(request => request.Model).NotEmpty();
        }
    }
}