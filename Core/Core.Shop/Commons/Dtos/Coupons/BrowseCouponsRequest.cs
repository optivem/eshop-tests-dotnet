using System.Diagnostics.CodeAnalysis;

namespace Optivem.EShop.SystemTest.Core.Shop.Commons.Dtos.Coupons;

/// <summary>
/// Marker DTO for browse coupons API request (no parameters required).
/// </summary>
[SuppressMessage("SonarAnalyzer.CSharp", "S2094:Remove this empty class", Justification = "Intentional marker DTO for API request")]
public class BrowseCouponsRequest
{
}