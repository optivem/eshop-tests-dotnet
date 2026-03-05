using Driver.Port.Clock.Dtos;
using Dsl.Core.Shared;

namespace Dsl.Core.Clock.UseCases.Base;

public class ClockErrorVerification : ResponseVerification<ClockErrorResponse>
{
    public ClockErrorVerification(ClockErrorResponse error, UseCaseContext context)
        : base(error, context)
    {
    }
}



