using Optivem.EShop.SystemTest.Driver.Api.Clock.Dtos;
using Driver.Core.Driver.Commons.Dsl;

namespace Optivem.EShop.SystemTest.Dsl.Clock.Dsl.UseCases.Base;

public class ClockErrorVerification : Driver.Core.Driver.Commons.Dsl.ResponseVerification<ClockErrorResponse>
{
    public ClockErrorVerification(ClockErrorResponse error, Driver.Core.Driver.Commons.Dsl.UseCaseContext context)
        : base(error, context)
    {
    }
}
