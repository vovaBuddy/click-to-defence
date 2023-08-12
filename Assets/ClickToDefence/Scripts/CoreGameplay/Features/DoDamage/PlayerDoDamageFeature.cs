using ClickToDefence.Scripts.CoreGameplay.Features.Enemies;
using ClickToDefence.Scripts.Infrastructure.Features;
using ClickToDefence.Scripts.Infrastructure.Services.Cameras;
using ClickToDefence.Scripts.Infrastructure.Services.Configs;
using ClickToDefence.Scripts.Infrastructure.Services.Models;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace ClickToDefence.Scripts.CoreGameplay.Features.DoDamage
{
	public class PlayerDoDamageFeature : IFeature
	{
		private readonly CameraService cameraService;
		private readonly ConfigsService configsService;
		private readonly ModelsService modelsService;
		private readonly EnemiesFactoryFeature enemiesFactoryFeature;

		public PlayerDoDamageFeature(
			CameraService cameraService, 
			ConfigsService configsService, 
			ModelsService modelsService, 
			EnemiesFactoryFeature enemiesFactoryFeature)
		{
			this.cameraService = cameraService;
			this.configsService = configsService;
			this.modelsService = modelsService;
			this.enemiesFactoryFeature = enemiesFactoryFeature;
		}

		public UniTask Init()
		{
			return UniTask.CompletedTask;
		}

		public UniTask Deinit()
		{
			return UniTask.CompletedTask;
		}

		public void Update()
		{
			if (Input.GetMouseButtonDown(0)) {
				RaycastHit2D rayHit = Physics2D.GetRayIntersection(
					cameraService.Camera.ScreenPointToRay(Input.mousePosition), configsService.coreGameplayConfig.enemies);

				if (rayHit.transform == null) return;

				var enemy = rayHit.transform.gameObject.GetComponent<Enemy>();

				enemy.hp -= modelsService.userModel.damage;

				if (enemy.hp <= 0) {
					enemiesFactoryFeature.DestroyEnemy(enemy);
				}
			}
		}

		public void Destroy()
		{
			
		}
	}
}