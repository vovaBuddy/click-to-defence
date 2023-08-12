using ClickToDefence.Scripts.CoreGameplay.Features.DoDamage;
using ClickToDefence.Scripts.CoreGameplay.Features.Enemies;
using ClickToDefence.Scripts.CoreGameplay.Features.EnemyBehaviors;
using ClickToDefence.Scripts.CoreGameplay.Features.Locations;
using ClickToDefence.Scripts.CoreGameplay.Features.Waves;
using ClickToDefence.Scripts.Infrastructure.DependenciesContainers;
using ClickToDefence.Scripts.Infrastructure.Features;
using ClickToDefence.Scripts.Infrastructure.Services;
using ClickToDefence.Scripts.Infrastructure.Services.Cameras;
using ClickToDefence.Scripts.Infrastructure.Services.Configs;
using ClickToDefence.Scripts.Infrastructure.Services.Content;
using ClickToDefence.Scripts.Infrastructure.Services.Models;
using ClickToDefence.Scripts.Infrastructure.StateMachines.Base;
using ClickToDefence.Scripts.Infrastructure.StateMachines.GameFlow;
using Cysharp.Threading.Tasks;

namespace ClickToDefence.Scripts.CoreGameplay.States
{
	public class BootstrapCoreGameplayGameFlowState : GameFlowState
	{
		public BootstrapCoreGameplayGameFlowState(
			IStateMachine stateMachine,
			DependenciesContainer<IService> services,
			DependenciesContainer<IFeature> features)
			: base(stateMachine, services, features)
		{
			
		}

		internal override async UniTask OnEnter()
		{
			var enemiesFactoryFeature = new EnemiesFactoryFeature(services.Resolve<ContentService>());
			features.Register(enemiesFactoryFeature);
			
			var locationFeature = new LocationFeature(
				services.Resolve<ConfigsService>(), services.Resolve<ContentService>());
			features.Register(locationFeature);
			
			var wavesFeature = new WaveFeature(
				services.Resolve<ModelsService>(),
				services.Resolve<ConfigsService>(),
				enemiesFactoryFeature,
				locationFeature);
			features.Register(wavesFeature);
			
			var enemyBehaviorFeature = new EnemyBehaviorFeature(enemiesFactoryFeature);
			features.Register(enemyBehaviorFeature);

			var playerDoDamageFeature = new PlayerDoDamageFeature(
				services.Resolve<CameraService>(),
				services.Resolve<ConfigsService>(),
				services.Resolve<ModelsService>(),
				enemiesFactoryFeature);
			features.Register(playerDoDamageFeature);
			
			await ChangeState<WaveCoreGameplayGameFlowState>();
			
			await base.OnEnter();
		}

		protected override void UpdateInternal()
		{
			
		}
	}
}