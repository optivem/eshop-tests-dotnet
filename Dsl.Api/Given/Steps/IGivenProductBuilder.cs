using Dsl.Api.Given.Steps.Base;

namespace Dsl.Api.Given.Steps;

public interface IGivenProductBuilder : IGivenStep
{
    IGivenProductBuilder WithSku(string? sku);

    IGivenProductBuilder WithUnitPrice(string? unitPrice);

    IGivenProductBuilder WithUnitPrice(decimal? unitPrice);
}