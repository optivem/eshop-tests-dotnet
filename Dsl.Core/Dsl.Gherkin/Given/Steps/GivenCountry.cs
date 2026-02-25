using Dsl.Api.Given.Steps;
using DslImpl.Gherkin.Given;
using static Optivem.EShop.SystemTest.Core.Gherkin.GherkinDefaults;

namespace Optivem.EShop.SystemTest.Core.Gherkin.Given;

public class GivenCountryBuilder : BaseGivenBuilder, IGivenCountryBuilder
{
    private string? _country;
    private string? _taxRate;

    public GivenCountryBuilder(GivenClause givenClause)
        : base(givenClause)
    {
        WithCode(DefaultCountry);
        WithTaxRate(DefaultTaxRate);
    }

    public GivenCountryBuilder WithCode(string country)
    {
        _country = country;
        return this;
    }

    IGivenCountryBuilder IGivenCountryBuilder.WithCode(string country) => WithCode(country);

    public GivenCountryBuilder WithTaxRate(string taxRate)
    {
        _taxRate = taxRate;
        return this;
    }

    IGivenCountryBuilder IGivenCountryBuilder.WithTaxRate(string taxRate) => WithTaxRate(taxRate);

    public GivenCountryBuilder WithTaxRate(decimal taxRate)
    {
        return WithTaxRate(taxRate.ToString());
    }

    IGivenCountryBuilder IGivenCountryBuilder.WithTaxRate(decimal taxRate) => WithTaxRate(taxRate);

    internal override async Task Execute(SystemDsl app)
    {
        (await app.Tax().ReturnsTaxRate()
            .Country(_country)
            .TaxRate(_taxRate)
            .Execute())
            .ShouldSucceed();
    }
}
