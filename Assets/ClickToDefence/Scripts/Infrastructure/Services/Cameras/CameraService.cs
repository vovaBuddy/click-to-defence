using ClickToDefence.Scripts.Infrastructure.Services.Configs;
using ClickToDefence.Scripts.Infrastructure.Services.Content;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace ClickToDefence.Scripts.Infrastructure.Services.Cameras
{
	public class CameraService : IService
	{
		public Camera Camera { get; private set; }
		
		private readonly ContentService contentService;
		private readonly ConfigsService configsService;

		public CameraService(ContentService contentService, ConfigsService configsService)
		{
			this.contentService = contentService;
			this.configsService = configsService;
		}

		public async UniTask Init()
		{
			Camera = await contentService.SpawnAsync<Camera>(configsService.appConfig.camera, null);
		}
	}
}