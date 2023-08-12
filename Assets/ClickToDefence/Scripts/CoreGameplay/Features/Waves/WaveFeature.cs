using ClickToDefence.Scripts.CoreGameplay.Features.Enemies;
using ClickToDefence.Scripts.CoreGameplay.Features.Locations;
using ClickToDefence.Scripts.CoreGameplay.Features.Waves.Configs;
using ClickToDefence.Scripts.Infrastructure.Features;
using ClickToDefence.Scripts.Infrastructure.Services.Configs;
using ClickToDefence.Scripts.Infrastructure.Services.Models;
using Cysharp.Threading.Tasks;
using UnityEngine;
#pragma warning disable 4014

namespace ClickToDefence.Scripts.CoreGameplay.Features.Waves
{
	public class WaveFeature : IFeature
	{
		private readonly ModelsService modelsService;
		private readonly ConfigsService configsService;
		
		private readonly EnemiesFactoryFeature enemiesFactoryFeature;
		private readonly LocationFeature locationFeature;

		private int waveUnitIndex;
		private float spawnDelayTimer;
		private int waveIndex;
		private WaveConfig waveConfig;

		public WaveFeature(ModelsService modelsService, 
			ConfigsService configsService, 
			EnemiesFactoryFeature enemiesFactoryFeature,
			LocationFeature locationFeature)
		{
			this.modelsService = modelsService;
			this.configsService = configsService;
			this.enemiesFactoryFeature = enemiesFactoryFeature;
			this.locationFeature = locationFeature;
		}

		public UniTask Init()
		{
			waveIndex = modelsService.userModel.waveIndex;
			waveConfig = configsService.coreGameplayConfig.waveConfigs[waveIndex % configsService.coreGameplayConfig.waveConfigs.Count];

			SetDelayTimer();
			
			return UniTask.CompletedTask;
		}

		public UniTask Deinit()
		{
			waveUnitIndex = 0;
			spawnDelayTimer = 0;
			
			return UniTask.CompletedTask;
		}

		public void Update()
		{
			if (IsLastEnemySpawned()) {
				return;
			}

			spawnDelayTimer -= Time.deltaTime;
			
			if (spawnDelayTimer <= 0.0f) {
				SpawnEnemyAsync();

				waveUnitIndex++;

				SetDelayTimer();
			}
		}
		
		public bool IsLastEnemySpawned()
		{
			return waveUnitIndex >= waveConfig.unitConfigs.Count;
		}

		private async UniTask SpawnEnemyAsync()
		{
			var unitConfig = waveConfig.unitConfigs[waveUnitIndex].config;
			var spawnPosition = locationFeature.EnemySpawnPoint();
			await enemiesFactoryFeature.SpawnEnemy<Enemy>(unitConfig, spawnPosition, Quaternion.identity);
		}

		private void SetDelayTimer()
		{
			if (waveUnitIndex < waveConfig.unitConfigs.Count) {
				spawnDelayTimer = waveConfig.unitConfigs[waveUnitIndex].waitSecondsBetweenSpawn;
			}
		}

		public void Destroy()
		{
			
		}
	}
}