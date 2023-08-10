using ClickToDefence.Scripts.Infrastructure.DependenciesContainers;
using ClickToDefence.Scripts.Infrastructure.Features;
using ClickToDefence.Scripts.Infrastructure.Services;
using ClickToDefence.Scripts.Infrastructure.StateMachines.Base;

namespace ClickToDefence.Scripts.Infrastructure.StateMachines.GameFlow
{
	public abstract class GameFlowState : BaseState
	{
		protected readonly DependenciesContainer<IService> services;
		protected readonly DependenciesContainer<IFeature> features;

		protected GameFlowState(
			IStateMachine stateMachine, 
			DependenciesContainer<IService> services,
			DependenciesContainer<IFeature> features)
			: base(stateMachine)
		{
			this.services = services;
			this.features = features;
		}
	}
}