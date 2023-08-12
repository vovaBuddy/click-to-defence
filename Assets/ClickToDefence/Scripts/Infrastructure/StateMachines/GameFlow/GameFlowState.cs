using ClickToDefence.Scripts.Infrastructure.DependenciesContainers;
using ClickToDefence.Scripts.Infrastructure.Features;
using ClickToDefence.Scripts.Infrastructure.Services;
using ClickToDefence.Scripts.Infrastructure.StateMachines.Base;
using Cysharp.Threading.Tasks;

namespace ClickToDefence.Scripts.Infrastructure.StateMachines.GameFlow
{
	public abstract class GameFlowState : BaseState
	{
		protected readonly DependenciesContainer<IService> services;
		protected readonly DependenciesContainer<IFeature> features;

		private bool isReady;

		protected GameFlowState(
			IStateMachine stateMachine, 
			DependenciesContainer<IService> services,
			DependenciesContainer<IFeature> features)
			: base(stateMachine)
		{
			this.services = services;
			this.features = features;
		}

		internal override UniTask OnEnter()
		{
			isReady = true;
			
			return base.OnEnter();
		}

		internal override void OnExit()
		{
			isReady = false;
			
			base.OnExit();
		}

		protected abstract void UpdateInternal();

		public void Update()
		{
			if (!isReady) {
				return;
			}

			UpdateInternal();
		}
	}
}