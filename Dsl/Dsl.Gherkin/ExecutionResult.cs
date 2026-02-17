using Commons.Dsl;
using Commons.Util;
using Optivem.EShop.SystemTest.Core.Shop.Dsl.UseCases.Base;

namespace Dsl.Gherkin
{
    public class ExecutionResult<TSuccessResponse, TSuccessVerification>
        where TSuccessVerification : ResponseVerification<TSuccessResponse>
    {
        internal ExecutionResult(ShopUseCaseResult<TSuccessResponse, TSuccessVerification> result,
            string? orderNumber, string? couponCode)
        {
            if (result == null)
            {
                throw new ArgumentException("Result cannot be null");
            }

            Result = result;
            OrderNumber = orderNumber;
            CouponCode = couponCode;
            Context = new ExecutionResultContext(orderNumber, couponCode);
        }

        public ShopUseCaseResult<TSuccessResponse, TSuccessVerification> Result { get; }

        public string? OrderNumber { get; }

        public string? CouponCode { get; }

        /// <summary>
        /// Context with order number and coupon code from the executed operation.
        /// </summary>
        public ExecutionResultContext Context { get; }
    }
}