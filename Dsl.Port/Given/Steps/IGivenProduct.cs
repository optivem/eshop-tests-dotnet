using Dsl.Api.Given.Steps.Base;

namespace Dsl.Api.Given.Steps;

public interface IGivenProduct : IGivenStep
{
    IGivenProduct WithSku(string? sku);

    IGivenProduct WithUnitPrice(string? unitPrice);

    IGivenProduct WithUnitPrice(decimal? unitPrice);
}