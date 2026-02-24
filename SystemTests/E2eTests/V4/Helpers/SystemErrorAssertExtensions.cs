using Optivem.EShop.SystemTest.Driver.Ports.Shop.Dtos.Error;
using Shouldly;

namespace Optivem.EShop.SystemTest.E2eTests.V4.Helpers;

public static class SystemErrorAssertExtensions
{
    public static void ShouldHaveMessageAndField(this SystemError error, string expectedMessage, string expectedField, string expectedFieldMessage)
    {
        error.Message.ShouldBe(expectedMessage);
        error.Fields.ShouldNotBeNull();
        error.Fields!.Any(f => f.Field == expectedField && f.Message == expectedFieldMessage).ShouldBeTrue(
            $"Expected field error {{ field: '{expectedField}', message: '{expectedFieldMessage}' }}. Actual: [{string.Join(", ", error.Fields.Select(f => $"{{ field: '{f.Field}', message: '{f.Message}' }}"))}]");
    }
}
