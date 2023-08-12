using System.Collections.Generic;
using UnityEngine;

namespace ClickToDefence.Scripts.CoreGameplay.Features.Waves.Configs
{
	[CreateAssetMenu(menuName = "ClickToDefence/Waves/Wave config", fileName = "WaveConfig", order = 0)]
	public class WaveConfig : ScriptableObject
	{
		public List<SpawnUnitConfig> unitConfigs;
	}
}