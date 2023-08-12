using UnityEngine;
using UnityEngine.AddressableAssets;

namespace ClickToDefence.Scripts.CoreGameplay.Features.Waves.Configs
{
	[CreateAssetMenu(menuName = "ClickToDefence/Enemies/Enemy unit config", fileName = "EnemyUnitConfig", order = 0)]
	public class EnemyUnitConfig : ScriptableObject
	{
		public AssetReference view;
		public float speed;
		public float hp;
		public float damage;
	}
}