using System;
using System.Collections.Generic;
using ClickToDefence.Scripts.CoreGameplay.Features.Waves.Configs;
using UnityEngine;

namespace ClickToDefence.Scripts.CoreGameplay.Configs
{

	[CreateAssetMenu(menuName = "ClickToDefence/Core gameplay config", fileName = "CoreGameplayConfig", order = 0)]
	public class CoreGameplayConfig : ScriptableObject
	{
		public LayerMask enemies;
		
		public List<WaveConfig> waveConfigs;
	}
}