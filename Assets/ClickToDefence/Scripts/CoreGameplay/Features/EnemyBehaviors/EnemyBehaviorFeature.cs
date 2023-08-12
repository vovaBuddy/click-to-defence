using ClickToDefence.Scripts.CoreGameplay.Features.Enemies;
using ClickToDefence.Scripts.Infrastructure.Features;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace ClickToDefence.Scripts.CoreGameplay.Features.EnemyBehaviors
{
	public class EnemyBehaviorFeature : IFeature
	{
		private readonly EnemiesFactoryFeature enemiesFactoryFeature;
		private Transform enemyTarget;

		public EnemyBehaviorFeature(EnemiesFactoryFeature enemiesFactoryFeature)
		{
			this.enemiesFactoryFeature = enemiesFactoryFeature;
		}

		public UniTask Init()
		{
			return UniTask.CompletedTask;
		}

		public void SetEnemyTarget(Transform target)
		{
			enemyTarget = target;
		}

		public UniTask Deinit()
		{
			enemyTarget = null;
			
			return UniTask.CompletedTask;
		}

		public void Update()
		{
			foreach (var enemy in enemiesFactoryFeature.Enemies) {
				enemy.transform.position = Vector3.MoveTowards(
					enemy.transform.position, enemyTarget.transform.position, enemy.speed * Time.deltaTime);
			}
		}

		public void Destroy()
		{
			
		}
	}
}