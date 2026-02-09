using Commons.Dsl;
using Optivem.EShop.SystemTest.Core;
using Optivem.EShop.SystemTest.Core.Gherkin.Then;
using Optivem.Testing;

namespace Dsl.Gherkin.Then
{
    public class ThenClause<TSuccessResponse, TSuccessVerification> : BaseClause
        where TSuccessVerification : ResponseVerification<TSuccessResponse>
    {
        private readonly SystemDsl _app;
        private readonly Func<Task<ExecutionResult<TSuccessResponse, TSuccessVerification>>> _lazyExecute;
        private ExecutionResult<TSuccessResponse, TSuccessVerification>? _executionResult;
        private bool _executionCompleted = false;

        public ThenClause(Channel channel, SystemDsl app, Func<Task<ExecutionResult<TSuccessResponse, TSuccessVerification>>> lazyExecute)
            : base(channel)
        {
            _app = app;
            _lazyExecute = lazyExecute;
        }

        public async Task<ThenSuccessBuilder<TSuccessResponse, TSuccessVerification>> ShouldSucceed()
        {
            var result = await GetExecutionResult();
            if (result == null)
            {
                throw new InvalidOperationException("Cannot verify success: no operation was executed");
            }
            var successVerification = result.Result.ShouldSucceed();
            return new ThenSuccessBuilder<TSuccessResponse, TSuccessVerification>(this, successVerification);
        }

        public async Task<ThenFailureBuilder<TSuccessResponse, TSuccessVerification>> ShouldFail()
        {
            var result = await GetExecutionResult();
            return new ThenFailureBuilder<TSuccessResponse, TSuccessVerification>(this, result.Result);
        }

        internal SystemDsl App => _app;

        internal async Task<ExecutionResult<TSuccessResponse, TSuccessVerification>> GetExecutionResult()
        {
            if (!_executionCompleted)
            {
                _executionResult = await _lazyExecute();
                _executionCompleted = true;
            }
            return _executionResult!;
        }
    }
}