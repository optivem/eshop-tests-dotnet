using Dsl.Core.Tax.UseCases;
using Dsl.Port.Then.Steps;

namespace Dsl.Core.Scenario.Then.Steps;

public class ThenCountry : IThenCountry
{
    private readonly GetTaxVerification _verification;

    public ThenCountry(GetTaxVerification verification)
    {
        _verification = verification;
    }

    public IThenCountry HasCountry(string country)
    {
        _verification.Country(country);
        return this;
    }

    public IThenCountry HasTaxRate(decimal taxRate)
    {
        _verification.TaxRate(taxRate);
        return this;
    }

    public IThenCountry HasTaxRateIsPositive()
    {
        _verification.TaxRateIsPositive();
        return this;
    }
}
