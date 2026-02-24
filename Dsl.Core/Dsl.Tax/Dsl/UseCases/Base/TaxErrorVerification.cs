using Optivem.EShop.SystemTest.Driver.Api.Tax.Dtos.Error;
using Driver.Core.Driver.Commons.Dsl;
using Shouldly;

namespace Optivem.EShop.SystemTest.Dsl.Tax.Dsl.UseCases.Base;

public class TaxErrorVerification : Driver.Core.Driver.Commons.Dsl.ResponseVerification<TaxErrorResponse>
{
    public TaxErrorVerification(TaxErrorResponse error, Driver.Core.Driver.Commons.Dsl.UseCaseContext context)
        : base(error, context)
    {
    }

    public TaxErrorVerification ErrorMessage(string expectedMessage)
    {
        var expandedExpectedMessage = Context.ExpandAliases(expectedMessage);
        var error = Response;
        var errorMessage = error.Message;

        errorMessage.ShouldBe(expandedExpectedMessage,
            $"Expected error message: '{expandedExpectedMessage}', but got: '{errorMessage}'");

        return this;
    }
}
