using ClickToDefence.Scripts.Infrastructure.Features;
using ClickToDefence.Scripts.Infrastructure.Services.Configs;
using ClickToDefence.Scripts.Infrastructure.Services.Content;
using Cysharp.Threading.Tasks;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ClickToDefence.Scripts.CoreGameplay.Features.Locations
{
	public class LocationFeature : IFeature
	{
		private readonly ConfigsService configsService;
		private readonly ContentService contentService;

		private Location location;

		public LocationFeature(ConfigsService configsService, ContentService contentService)
		{
			this.configsService = configsService;
			this.contentService = contentService;
		}

		public async UniTask Init()
		{
			location = await contentService.SpawnAsync<Location>(
				configsService.locationsConfig.locationPrefab, Vector3.zero, quaternion.identity);
		}

		public UniTask Deinit()
		{
			return UniTask.CompletedTask;
		}

		public void Update()
		{ }

		public void Destroy()
		{
			contentService.Releace(location.gameObject);
		}

		public Transform Tower()
		{
			return location.towerSpawnPoint.transform;
		}

		public Vector3 EnemySpawnPoint()
		{
			var random = Random.insideUnitCircle.normalized * 10;
			return location.towerSpawnPoint.transform.position + new Vector3(random.x, random.y, 0);
		}
	}
}