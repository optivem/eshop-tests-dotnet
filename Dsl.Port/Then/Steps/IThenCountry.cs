namespace Dsl.Port.Then.Steps;

public interface IThenCountry
{
    IThenCountry HasCountry(string country);

    IThenCountry HasTaxRate(decimal taxRate);

    IThenCountry HasTaxRateIsPositive();
}
