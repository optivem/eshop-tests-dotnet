using Common;

namespace Driver.Shared.Dsl;

public class VoidVerification : ResponseVerification<VoidValue>
{
    public VoidVerification(VoidValue response, UseCaseContext context)
        : base(response, context)
    {
    }
}
