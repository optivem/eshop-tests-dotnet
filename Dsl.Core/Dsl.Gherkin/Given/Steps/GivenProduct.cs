using Commons.Util;
using Dsl.Api.Given.Steps;
using DslImpl.Gherkin.Given;
using static Optivem.EShop.SystemTest.Core.Gherkin.GherkinDefaults;

namespace Optivem.EShop.SystemTest.Core.Gherkin.Given;

public class GivenProductBuilder : BaseGivenBuilder, IGivenProductBuilder
{
    private string? _sku;
    private string? _unitPrice;

    public GivenProductBuilder(GivenStage givenClause)
        : base(givenClause)
    {
        WithSku(DefaultSku);
        WithUnitPrice(DefaultUnitPrice);
    }

    public GivenProductBuilder WithSku(string? sku)
    {
        _sku = sku;
        return this;
    }

    IGivenProductBuilder IGivenProductBuilder.WithSku(string? sku) => WithSku(sku);

    public GivenProductBuilder WithUnitPrice(string? unitPrice)
    {
        _unitPrice = unitPrice;
        return this;
    }

    IGivenProductBuilder IGivenProductBuilder.WithUnitPrice(string? unitPrice) => WithUnitPrice(unitPrice);

    public GivenProductBuilder WithUnitPrice(decimal? unitPrice)
    {
        return WithUnitPrice(Converter.FromDecimal(unitPrice));
    }

    IGivenProductBuilder IGivenProductBuilder.WithUnitPrice(decimal? unitPrice) => WithUnitPrice(unitPrice);

    internal override async Task Execute(SystemDsl app)
    {
        (await app.Erp().ReturnsProduct()
            .Sku(_sku)
            .UnitPrice(_unitPrice)
            .Execute())
            .ShouldSucceed();
    }
}
