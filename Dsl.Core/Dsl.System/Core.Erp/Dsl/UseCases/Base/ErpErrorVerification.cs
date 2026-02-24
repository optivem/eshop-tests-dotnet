using Optivem.EShop.SystemTest.Driver.Api.Erp.Dtos.Error;
using Driver.Shared.Dsl;
using Shouldly;

namespace Optivem.EShop.SystemTest.Core.Erp.Dsl.UseCases.Base;

public class ErpErrorVerification : ResponseVerification<ErpErrorResponse>
{
    public ErpErrorVerification(ErpErrorResponse error, UseCaseContext context)
        : base(error, context)
    {
    }

    public ErpErrorVerification ErrorMessage(string expectedMessage)
    {
        var expandedExpectedMessage = Context.ExpandAliases(expectedMessage);
        var error = Response;
        var errorMessage = error.Message;

        errorMessage.ShouldBe(expandedExpectedMessage,
            $"Expected error message: '{expandedExpectedMessage}', but got: '{errorMessage}'");

        return this;
    }
}
