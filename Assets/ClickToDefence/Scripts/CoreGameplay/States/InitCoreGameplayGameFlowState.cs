using ClickToDefence.Scripts.Infrastructure.DependenciesContainers;
using ClickToDefence.Scripts.Infrastructure.Features;
using ClickToDefence.Scripts.Infrastructure.Services;
using ClickToDefence.Scripts.Infrastructure.StateMachines.Base;
using ClickToDefence.Scripts.Infrastructure.StateMachines.GameFlow;

namespace ClickToDefence.Scripts.CoreGameplay.States
{
	public class InitCoreGameplayGameFlowState : GameFlowState
	{
		public InitCoreGameplayGameFlowState(
			IStateMachine stateMachine,
			DependenciesContainer<IService> services,
			DependenciesContainer<IFeature> features)
			: base(stateMachine, services, features)
		{
			
		}
	}
}