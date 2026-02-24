using Driver.Core.Driver.Commons.Dsl;
using Commons.Util;
using Optivem.EShop.SystemTest.Dsl.Shop.Dsl.UseCases.Base;
using Optivem.EShop.SystemTest.Driver.Api.Shop.Dtos.Error;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsl.Gherkin
{
    public class ExecutionResultBuilder<TSuccessResponse, TSuccessVerification>
        where TSuccessVerification : Driver.Core.Driver.Commons.Dsl.ResponseVerification<TSuccessResponse>
    {
        private readonly ShopDriver.Core.Driver.Commons.Dsl.UseCaseResult<TSuccessResponse, TSuccessVerification> _result;
        private string? _orderNumber;
        private string? _couponCode;

        internal ExecutionResultBuilder(Driver.Core.Driver.Commons.Dsl.UseCaseResult<TSuccessResponse, SystemError, TSuccessVerification, SystemErrorFailureVerification> result)
        {
            // Cast to derived type - the result is always a ShopDriver.Core.Driver.Commons.Dsl.UseCaseResult at runtime
            _result = (ShopDriver.Core.Driver.Commons.Dsl.UseCaseResult<TSuccessResponse, TSuccessVerification>)result;
        }

        public ExecutionResultBuilder<TSuccessResponse, TSuccessVerification> OrderNumber(string? orderNumber)
        {
            _orderNumber = orderNumber;
            return this;
        }

        public ExecutionResultBuilder<TSuccessResponse, TSuccessVerification> CouponCode(string? couponCode)
        {
            _couponCode = couponCode;
            return this;
        }

        public ExecutionResult<TSuccessResponse, TSuccessVerification> Build()
        {
            return new ExecutionResult<TSuccessResponse, TSuccessVerification>(
                _result,
                _orderNumber,
                _couponCode);
        }
    }
}
