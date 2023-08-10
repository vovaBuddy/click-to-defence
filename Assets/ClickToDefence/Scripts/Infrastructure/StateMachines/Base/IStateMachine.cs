namespace ClickToDefence.Scripts.Infrastructure.StateMachines.Base
{
	public interface IStateMachine
	{
		internal void ChangeState<TState>() where TState : IState;
	}
}