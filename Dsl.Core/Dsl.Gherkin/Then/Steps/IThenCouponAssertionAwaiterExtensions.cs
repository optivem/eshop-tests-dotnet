using System.Reflection;
using System.Runtime.CompilerServices;

namespace Dsl.Api.Then.Steps;

public static class IThenCouponAssertionAwaiterExtensions
{
    public static TaskAwaiter GetAwaiter(this IThenCouponAssertion assertion)
    {
        var method = assertion.GetType().GetMethod(nameof(GetAwaiter), BindingFlags.Public | BindingFlags.Instance, Type.EmptyTypes);

        if (method == null)
        {
            throw new InvalidOperationException($"Type '{assertion.GetType().FullName}' does not expose a public GetAwaiter() method.");
        }

        var awaiter = method.Invoke(assertion, null);

        if (awaiter is TaskAwaiter taskAwaiter)
        {
            return taskAwaiter;
        }

        throw new InvalidOperationException($"Type '{assertion.GetType().FullName}' returned an unexpected awaiter type.");
    }
}
