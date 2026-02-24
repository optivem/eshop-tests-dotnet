using Optivem.EShop.SystemTest.Driver.Api.Clock.Dtos;
using Driver.Shared.Dsl;

namespace Optivem.EShop.SystemTest.Core.Clock.Dsl.UseCases.Base;

public class ClockErrorVerification : ResponseVerification<ClockErrorResponse>
{
    public ClockErrorVerification(ClockErrorResponse error, UseCaseContext context)
        : base(error, context)
    {
    }
}
