namespace Optivem.EShop.SystemTest.Driver.Ports.Tax.Dtos;

public class GetTaxResponse
{
    public required string Country { get; set; }
    public decimal TaxRate { get; set; }
}
