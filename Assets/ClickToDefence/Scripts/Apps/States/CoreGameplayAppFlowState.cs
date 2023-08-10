using ClickToDefence.Scripts.Infrastructure.DependenciesContainers;
using ClickToDefence.Scripts.Infrastructure.Services;
using ClickToDefence.Scripts.Infrastructure.StateMachines.AppFlow;
using ClickToDefence.Scripts.Infrastructure.StateMachines.Base;

namespace ClickToDefence.Scripts.Apps.States
{
	public class CoreGameplayAppFlowState : AppFlowState
	{
		public CoreGameplayAppFlowState(IStateMachine stateMachine, DependenciesContainer<IService> services)
			: base(stateMachine, services)
		{
			
		}
	}
}