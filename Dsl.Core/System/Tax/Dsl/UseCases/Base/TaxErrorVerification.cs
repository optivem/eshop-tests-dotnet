using Driver.Api.Tax.Dtos.Error;
using Dsl.Common;
using Shouldly;

namespace Optivem.EShop.SystemTest.Core.Tax.Dsl.UseCases.Base;

public class TaxErrorVerification : ResponseVerification<TaxErrorResponse>
{
    public TaxErrorVerification(TaxErrorResponse error, UseCaseContext context)
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

