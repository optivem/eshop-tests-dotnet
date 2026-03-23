# .NET-specific instructions

_Shared instructions (ATDD rules, architecture, git safety) are in the `eshop-tests` repository, loaded automatically via the workspace._

## Test Location

- **Acceptance tests** go in `SystemTests/V8/AcceptanceTests/`
- **Contract tests** go in `SystemTests/V8/ExternalSystemContractTests/<System>/` (e.g. `Erp/`, `Tax/`, `Clock/`)
- Do **NOT** use V1–V7 directories for new acceptance/contract tests. All new tests go in V8.

## Test Pattern

Acceptance tests use the ScenarioDSL pattern — **not** raw driver calls.

```csharp
public class PlaceOrderPositiveTest : BaseAcceptanceTest
{
    [Theory]
    [ChannelData(ChannelType.UI, ChannelType.API)]
    public async Task CanPlaceOrder(Channel channel)
    {
        await Scenario(channel)
            .Given().Product().WithSku("SKU-001").WithUnitPrice("10.00")
            .When().PlaceOrder().WithSku("SKU-001").WithQuantity("2")
            .Then().ShouldSucceed();
    }
}
```

Key rules:
- Extend `BaseAcceptanceTest` (in `V8/AcceptanceTests/Base/`)
- Use `[Theory]` + `[ChannelData(ChannelType.UI, ChannelType.API)]` with a `Channel channel` parameter — **no separate API/UI subclasses**
- Use `await Scenario(channel).Given()...When()...Then()` DSL — not raw drivers
- File names: `<UseCase>PositiveTest.cs` and `<UseCase>NegativeTest.cs` (one file each)
- Contract tests extend `BaseExternalSystemContractTest` (in `V8/ExternalSystemContractTests/Base/`)
