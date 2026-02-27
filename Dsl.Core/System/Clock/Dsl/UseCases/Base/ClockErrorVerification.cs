using Driver.Api.Clock.Dtos;
using Dsl.Common;

namespace Driver.Core.Clock.Dsl.UseCases.Base;

public class ClockErrorVerification : ResponseVerification<ClockErrorResponse>
{
    public ClockErrorVerification(ClockErrorResponse error, UseCaseContext context)
        : base(error, context)
    {
    }
}


