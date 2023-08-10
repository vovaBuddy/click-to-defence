using ClickToDefence.Scripts.Infrastructure.Services.Configs;
using ClickToDefence.Scripts.Infrastructure.Services.Content;
using ClickToDefence.Scripts.UI;
using Cysharp.Threading.Tasks;

namespace ClickToDefence.Scripts.Infrastructure.Services.UI
{
	public class UIService : IService
	{
		public readonly UIViewModel uiViewModel = new UIViewModel();
		
		private readonly ContentService contentService;
		private readonly ConfigsService configsService;

		private UIView uiView;

		public UIService(ContentService contentService, ConfigsService configsService)
		{
			this.contentService = contentService;
			this.configsService = configsService;
		}

		public async UniTask Init()
		{
			uiView = await contentService.SpawnAsync<UIView>(configsService.appConfig.uiView, null);
			uiView.Construct(uiViewModel);
		}
	}
}