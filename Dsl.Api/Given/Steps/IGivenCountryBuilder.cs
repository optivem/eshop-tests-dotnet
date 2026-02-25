using Dsl.Api.Given.Steps.Base;

namespace Dsl.Api.Given.Steps;

public interface IGivenCountryBuilder : IGivenStep
{
    IGivenCountryBuilder WithCode(string country);

    IGivenCountryBuilder WithTaxRate(string taxRate);

    IGivenCountryBuilder WithTaxRate(decimal taxRate);
}