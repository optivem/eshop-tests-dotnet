using Driver.Port.Clock.Dtos;
using Dsl.Common;

namespace Dsl.Core.Clock.Dsl.UseCases.Base;

public class ClockErrorVerification : ResponseVerification<ClockErrorResponse>
{
    public ClockErrorVerification(ClockErrorResponse error, UseCaseContext context)
        : base(error, context)
    {
    }
}



