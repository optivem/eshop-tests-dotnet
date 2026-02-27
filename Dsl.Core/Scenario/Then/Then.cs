using Dsl.Common;
using Dsl.Api.Then;
using Dsl.Api.Then.Steps;
using Optivem.EShop.SystemTest.Core;
using Optivem.Testing;

namespace DslImpl.Scenario.Then
{
    public class ThenStage<TSuccessResponse, TSuccessVerification> : BaseClause, IThen
        where TSuccessVerification : ResponseVerification<TSuccessResponse>
    {
        private readonly SystemDsl _app;
        private readonly Func<Task<ExecutionResult<TSuccessResponse, TSuccessVerification>>> _lazyExecute;
        private ExecutionResult<TSuccessResponse, TSuccessVerification>? _executionResult;
        private bool _executionCompleted = false;

        public ThenStage(Channel channel, SystemDsl app, Func<Task<ExecutionResult<TSuccessResponse, TSuccessVerification>>> lazyExecute)
            : base(channel)
        {
            _app = app;
            _lazyExecute = lazyExecute;
        }

        public ThenSuccess<TSuccessResponse, TSuccessVerification> ShouldSucceed()
        {
            return new ThenSuccess<TSuccessResponse, TSuccessVerification>(this);
        }

        IThenSuccess IThen.ShouldSucceed() => ShouldSucceed();

        public ThenFailure<TSuccessResponse, TSuccessVerification> ShouldFail()
        {
            return new ThenFailure<TSuccessResponse, TSuccessVerification>(this);
        }

        IThenFailure IThen.ShouldFail() => ShouldFail();

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
