namespace Optivem.EShop.SystemTest.Infra.Tax.Client.Dtos;

public class ExtCountryDetailsResponse
{
    public required string Id { get; set; }
    public required string CountryName { get; set; }
    public decimal TaxRate { get; set; }
}