using Dsl.Api.Given.Steps.Base;

namespace Dsl.Api.Given.Steps;

public interface IGivenCountry : IGivenStep
{
    IGivenCountry WithCode(string country);

    IGivenCountry WithTaxRate(string taxRate);

    IGivenCountry WithTaxRate(decimal taxRate);
}