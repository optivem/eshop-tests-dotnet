using Common;

namespace Dsl.Common;

public class VoidVerification : ResponseVerification<VoidValue>
{
    public VoidVerification(VoidValue response, UseCaseContext context)
        : base(response, context)
    {
    }
}
