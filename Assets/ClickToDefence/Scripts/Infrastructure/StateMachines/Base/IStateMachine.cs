using Cysharp.Threading.Tasks;

namespace ClickToDefence.Scripts.Infrastructure.StateMachines.Base
{
	public interface IStateMachine
	{
		internal UniTask ChangeState<TState>() where TState : IState;
	}
}