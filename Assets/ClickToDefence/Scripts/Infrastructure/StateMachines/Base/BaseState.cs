using Cysharp.Threading.Tasks;

namespace ClickToDefence.Scripts.Infrastructure.StateMachines.Base
{
	public class BaseState : IState
	{
		private IStateMachine stateMachine;

		public BaseState(IStateMachine stateMachine)
		{
			this.stateMachine = stateMachine;
		}

		internal virtual UniTask OnEnter()
		{
			return UniTask.CompletedTask;
		}
		
		internal virtual void OnExit() { }

		protected async UniTask ChangeState<TState>() where TState : IState
		{
			await stateMachine.ChangeState<TState>();
		}
	}
}