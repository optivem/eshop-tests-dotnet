using Commons.Dsl;
using Optivem.EShop.SystemTest.Core;
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

        public ThenSuccessVerifier<TSuccessResponse, TSuccessVerification> ShouldSucceed()
        {
            return new ThenSuccessVerifier<TSuccessResponse, TSuccessVerification>(this);
        }

        public ThenFailureVerifier<TSuccessResponse, TSuccessVerification> ShouldFail()
        {
            return new ThenFailureVerifier<TSuccessResponse, TSuccessVerification>(this);
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