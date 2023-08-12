using System;

namespace ClickToDefence.Scripts.CoreGameplay.Features.Waves.Configs
{
	[Serializable]
	public class SpawnUnitConfig
	{
		public float waitSecondsBetweenSpawn;
		public EnemyUnitConfig config;
	}
}