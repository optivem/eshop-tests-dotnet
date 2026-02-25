using System.Runtime.CompilerServices;
using Optivem.EShop.SystemTest.Driver.Api.Shop.Dtos;

namespace Dsl.Api.Then.Steps;

public interface IThenOrderAssertion
{
    IThenOrderAssertion HasSku(string expectedSku);

    IThenOrderAssertion HasQuantity(int expectedQuantity);

    IThenOrderAssertion HasCountry(string expectedCountry);

    IThenOrderAssertion HasUnitPrice(decimal expectedUnitPrice);

    IThenOrderAssertion HasBasePrice(decimal expectedBasePrice);

    IThenOrderAssertion HasBasePrice(string basePrice);

    IThenOrderAssertion HasSubtotalPrice(decimal expectedSubtotalPrice);

    IThenOrderAssertion HasSubtotalPrice(string expectedSubtotalPrice);

    IThenOrderAssertion HasTotalPrice(decimal expectedTotalPrice);

    IThenOrderAssertion HasTotalPrice(string expectedTotalPrice);

    IThenOrderAssertion HasStatus(OrderStatus expectedStatus);

    IThenOrderAssertion HasDiscountRateGreaterThanOrEqualToZero();

    IThenOrderAssertion HasDiscountRate(decimal expectedDiscountRate);

    IThenOrderAssertion HasDiscountAmount(decimal expectedDiscountAmount);

    IThenOrderAssertion HasDiscountAmount(string expectedDiscountAmount);

    IThenOrderAssertion HasAppliedCoupon(string expectedCouponCode);

    IThenOrderAssertion HasAppliedCoupon();

    IThenOrderAssertion HasDiscountAmountGreaterThanOrEqualToZero();

    IThenOrderAssertion HasSubtotalPriceGreaterThanZero();

    IThenOrderAssertion HasTaxRate(decimal expectedTaxRate);

    IThenOrderAssertion HasTaxRate(string expectedTaxRate);

    IThenOrderAssertion HasTaxRateGreaterThanOrEqualToZero();

    IThenOrderAssertion HasTaxAmount(string expectedTaxAmount);

    IThenOrderAssertion HasTaxAmountGreaterThanOrEqualToZero();

    IThenOrderAssertion HasTotalPriceGreaterThanZero();

    IThenOrderAssertion HasOrderNumberPrefix(string expectedPrefix);

    TaskAwaiter GetAwaiter();
}