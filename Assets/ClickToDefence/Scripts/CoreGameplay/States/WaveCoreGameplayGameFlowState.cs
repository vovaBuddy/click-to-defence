using ClickToDefence.Scripts.CoreGameplay.Features.DoDamage;
using ClickToDefence.Scripts.CoreGameplay.Features.Enemies;
using ClickToDefence.Scripts.CoreGameplay.Features.EnemyBehaviors;
using ClickToDefence.Scripts.CoreGameplay.Features.Locations;
using ClickToDefence.Scripts.CoreGameplay.Features.Waves;
using ClickToDefence.Scripts.Infrastructure.DependenciesContainers;
using ClickToDefence.Scripts.Infrastructure.Features;
using ClickToDefence.Scripts.Infrastructure.Services;
using ClickToDefence.Scripts.Infrastructure.StateMachines.Base;
using ClickToDefence.Scripts.Infrastructure.StateMachines.GameFlow;
using Cysharp.Threading.Tasks;

#pragma warning disable 4014

namespace ClickToDefence.Scripts.CoreGameplay.States
{
	public class WaveCoreGameplayGameFlowState : GameFlowState
	{
		private WaveFeature waveFeature;
		private EnemyBehaviorFeature enemyBehaviorFeature;
		private LocationFeature locationFeature;
		private PlayerDoDamageFeature playerDoDamageFeature;
		private EnemiesFactoryFeature enemiesFactoryFeature;

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
			playerDoDamageFeature = features.Resolve<PlayerDoDamageFeature>();
			enemiesFactoryFeature = features.Resolve<EnemiesFactoryFeature>();

			await locationFeature.Init();
			await waveFeature.Init();
			await enemyBehaviorFeature.Init();
			await playerDoDamageFeature.Init();
			await enemiesFactoryFeature.Init();
			
			enemyBehaviorFeature.SetEnemyTarget(locationFeature.Tower());
			
			await base.OnEnter();
		}

		internal override void OnExit()
		{
			locationFeature.Deinit();
			waveFeature.Deinit();
			enemiesFactoryFeature.Deinit();
			playerDoDamageFeature.Deinit();
			enemyBehaviorFeature.Deinit();
			
			base.OnExit();
		}

		protected override void UpdateInternal()
		{
			waveFeature.Update();
			playerDoDamageFeature.Update();
			enemyBehaviorFeature.Update();

			if (waveFeature.IsLastEnemySpawned() && !enemiesFactoryFeature.HasAliveEnemies()) {
				ChangeState<ResultCoreGameplayGameFlowState>();
				return;
			}
		}
	}
}