namespace ClickToDefence.Scripts.Infrastructure.StateMachines.Base
{
	public class BaseState : IState
	{
		private IStateMachine stateMachine;

		public BaseState(IStateMachine stateMachine)
		{
			this.stateMachine = stateMachine;
		}

		internal virtual void OnEnter() { }
		internal virtual void OnExit() { }

		protected void ChangeState<TState>() where TState : IState
		{
			stateMachine.ChangeState<TState>();
		}
	}
}