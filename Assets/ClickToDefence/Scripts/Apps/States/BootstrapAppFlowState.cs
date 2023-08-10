using ClickToDefence.Scripts.Configs;
using ClickToDefence.Scripts.Infrastructure.DependenciesContainers;
using ClickToDefence.Scripts.Infrastructure.Services;
using ClickToDefence.Scripts.Infrastructure.Services.Cameras;
using ClickToDefence.Scripts.Infrastructure.Services.Configs;
using ClickToDefence.Scripts.Infrastructure.Services.Content;
using ClickToDefence.Scripts.Infrastructure.Services.Models;
using ClickToDefence.Scripts.Infrastructure.Services.UI;
using ClickToDefence.Scripts.Infrastructure.StateMachines;
using ClickToDefence.Scripts.Infrastructure.StateMachines.AppFlow;
using ClickToDefence.Scripts.Infrastructure.StateMachines.Base;
using Cysharp.Threading.Tasks;

namespace ClickToDefence.Scripts.Apps.States
{
	public class BootstrapAppFlowState : AppFlowState
	{
		private ContentService contentService;
		private ConfigsService configsService;
		private CameraService cameraService;
		private UIService uiService;
		private ModelsService modelsService;
		
		public BootstrapAppFlowState(IStateMachine stateMachine, DependenciesContainer<IService> services) 
			: base(stateMachine, services) { }

		internal override async void OnEnter()
		{
			base.OnEnter();

			BootstrapContentService();
			
			await BootstrapConfigsService();

			await BootstrapCameraService();

			await BootstrapUIService();

			BootstrapModelsService();
		}

		private void BootstrapContentService()
		{
			contentService = new ContentService();
			services.Register(contentService);
		}

		private async UniTask BootstrapConfigsService()
		{
			var appConfig = await contentService.LoadAsync<AppConfig>(AppConfig.AssetReferenceKey);
			configsService = new ConfigsService(appConfig);
			services.Register(configsService);
		}

		private async UniTask BootstrapCameraService()
		{
			cameraService = new CameraService(contentService, configsService);
			await cameraService.Init();
			services.Register(cameraService);
		}

		private async UniTask BootstrapUIService()
		{
			uiService = new UIService(contentService, configsService);
			await uiService.Init();
			services.Register(uiService);
		}

		private void BootstrapModelsService()
		{
			modelsService = new ModelsService();
			services.Register(modelsService);
		}
	}
}