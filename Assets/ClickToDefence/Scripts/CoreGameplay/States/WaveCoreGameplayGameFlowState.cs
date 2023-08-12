using ClickToDefence.Scripts.CoreGameplay.Features.EnemyBehaviors;
using ClickToDefence.Scripts.CoreGameplay.Features.Locations;
using ClickToDefence.Scripts.CoreGameplay.Features.Waves;
using ClickToDefence.Scripts.Infrastructure.DependenciesContainers;
using ClickToDefence.Scripts.Infrastructure.Features;
using ClickToDefence.Scripts.Infrastructure.Services;
using ClickToDefence.Scripts.Infrastructure.StateMachines.Base;
using ClickToDefence.Scripts.Infrastructure.StateMachines.GameFlow;
using Cysharp.Threading.Tasks;

namespace ClickToDefence.Scripts.CoreGameplay.States
{
	public class WaveCoreGameplayGameFlowState : GameFlowState
	{
		private WaveFeature waveFeature;
		private EnemyBehaviorFeature enemyBehaviorFeature;
		private LocationFeature locationFeature;

		public WaveCoreGameplayGameFlowState(
			IStateMachine stateMachine,
			DependenciesContainer<IService> services,
			DependenciesContainer<IFeature> features)
			: base(stateMachine, services, features)
		{ }

		internal override async UniTask OnEnter()
		{
			waveFeature = features.Resolve<WaveFeature>();
			enemyBehaviorFeature = features.Resolve<EnemyBehaviorFeature>();
			locationFeature = features.Resolve<LocationFeature>();

			await locationFeature.Init();
			await waveFeature.Init();
			await enemyBehaviorFeature.Init();
			
			enemyBehaviorFeature.SetEnemyTarget(locationFeature.Tower());
			
			base.OnEnter();
		}

		protected override void UpdateInternal()
		{
			waveFeature.Update();
			enemyBehaviorFeature.Update();
		}
	}
}