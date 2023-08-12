using System.Collections.Generic;
using ClickToDefence.Scripts.CoreGameplay.Features.Waves.Configs;
using ClickToDefence.Scripts.Infrastructure.Features;
using ClickToDefence.Scripts.Infrastructure.Services.Content;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace ClickToDefence.Scripts.CoreGameplay.Features.Enemies
{
	public class EnemiesFactoryFeature : IFeature
	{
		private readonly ContentService contentService;
		
		private List<Enemy> enemies;

		public IReadOnlyCollection<Enemy> Enemies => enemies;

		public EnemiesFactoryFeature(ContentService contentService)
		{
			this.contentService = contentService;
			
			enemies = new List<Enemy>();
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
		{ }

		public void Destroy()
		{
			foreach (var enemy in enemies) {
				contentService.Releace(enemy.gameObject);
			}
			
			enemies.Clear();
		}

		public async UniTask<T> SpawnEnemy<T>(EnemyUnitConfig config, Vector3 position, Quaternion rotation) where T : Enemy
		{
			var enemy = await contentService.SpawnAsync<T>(config.view, position, rotation);
			enemies.Add(enemy);

			enemy.hp = config.hp;
			enemy.speed = config.speed;

			return enemy;
		}

		public void DestroyEnemy(Enemy enemy)
		{
			enemies.Remove(enemy);
			contentService.Releace(enemy.gameObject);
		}
	}
}