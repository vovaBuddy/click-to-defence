using ClickToDefence.Scripts.Infrastructure.DependenciesContainers;
using ClickToDefence.Scripts.Infrastructure.Services;
using ClickToDefence.Scripts.Infrastructure.StateMachines.Base;

namespace ClickToDefence.Scripts.Infrastructure.StateMachines.AppFlow
{
	public abstract class AppFlowState : BaseState
	{
		protected readonly DependenciesContainer<IService> services;

		protected AppFlowState(IStateMachine stateMachine, DependenciesContainer<IService> services)
		: base(stateMachine)
		{
			this.services = services;
		}
	}
}