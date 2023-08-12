using ClickToDefence.Scripts.Infrastructure.DependenciesContainers;
using ClickToDefence.Scripts.Infrastructure.Features;
using ClickToDefence.Scripts.Infrastructure.Services;
using ClickToDefence.Scripts.Infrastructure.Services.Models;
using ClickToDefence.Scripts.Infrastructure.Services.UI;
using ClickToDefence.Scripts.Infrastructure.StateMachines.Base;
using ClickToDefence.Scripts.Infrastructure.StateMachines.GameFlow;
using Cysharp.Threading.Tasks;
#pragma warning disable 4014

namespace ClickToDefence.Scripts.CoreGameplay.States
{
	public class ResultCoreGameplayGameFlowState : GameFlowState
	{
		private UIService uiService;
		private ModelsService modelsService;
		
		public ResultCoreGameplayGameFlowState(
			IStateMachine stateMachine,
			DependenciesContainer<IService> services,
			DependenciesContainer<IFeature> features)
			: base(stateMachine, services, features)
		{
			uiService = services.Resolve<UIService>();
			modelsService = services.Resolve<ModelsService>();
			
			uiService.uiViewModel.windowViewModel.next.Subscribe(() => NextWave());
		}

		internal override UniTask OnEnter()
		{
			uiService.uiViewModel.windowViewModel.isActive.Value = true;
			uiService.uiViewModel.windowViewModel.waveNumber.Value = modelsService.userModel.waveIndex;
			
			return base.OnEnter();
		}

		internal override void OnExit()
		{
			base.OnExit();
			
			uiService.uiViewModel.windowViewModel.isActive.Value = false;
		}

		protected override void UpdateInternal()
		{
			
		}

		private async UniTask NextWave()
		{
			modelsService.userModel.waveIndex++;
			await ChangeState<WaveCoreGameplayGameFlowState>();
		}
	}
}