using Optivem.EShop.SystemTest.Driver.Api.Erp.Dtos.Error;
using Driver.Core.Driver.Commons.Dsl;
using Shouldly;

namespace Optivem.EShop.SystemTest.Dsl.Erp.Dsl.UseCases.Base;

public class ErpErrorVerification : Driver.Core.Driver.Commons.Dsl.ResponseVerification<ErpErrorResponse>
{
    public ErpErrorVerification(ErpErrorResponse error, Driver.Core.Driver.Commons.Dsl.UseCaseContext context)
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
