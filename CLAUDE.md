# .NET-specific instructions

_Shared instructions (ATDD rules, architecture, git safety) are in the `eshop-tests` repository, loaded automatically via the workspace._

## Test Location

- **Acceptance tests** go in `SystemTests/V7/AcceptanceTests/`
- **Contract tests** go in `SystemTests/V7/ExternalSystemContractTests/<System>/` (e.g. `Erp/`, `Tax/`, `Clock/`)
- Do **NOT** use V1–V6 directories. All new tests go in V7.

## Test Pattern

Acceptance tests use the ScenarioDSL pattern — **not** raw driver calls.

```csharp
public class SubmitReviewPositiveTest : BaseAcceptanceTest
{
    [Theory]
    [ChannelData(ChannelType.UI, ChannelType.API)]
    public async Task CanSubmitReviewOnDeliveredOrder(Channel channel)
    {
        await Scenario(channel)
            .Given().Order().WithStatus(OrderStatus.Delivered)
            .When().SubmitReview().WithRating("5")
            .Then().ShouldSucceed();
    }
}
```

Key rules:
- Extend `BaseAcceptanceTest` (in `V7/AcceptanceTests/Base/`)
- Use `[Theory]` + `[ChannelData(ChannelType.UI, ChannelType.API)]` with a `Channel channel` parameter — **no separate API/UI subclasses**
- Use `await Scenario(channel).Given()...When()...Then()` DSL — not raw drivers
- File names: `<UseCase>PositiveTest.cs` and `<UseCase>NegativeTest.cs` (one file each)
- Contract tests extend `BaseExternalSystemContractTest` (in `V7/ExternalSystemContractTests/Base/`)
