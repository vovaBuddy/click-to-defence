using UnityEngine;
using UnityEngine.AddressableAssets;

namespace ClickToDefence.Scripts.CoreGameplay.Features.Locations.Configs
{
	[CreateAssetMenu(menuName = "ClickToDefence/Create Locations config", fileName = "LocationsConfig", order = 0)]
	public class LocationsConfig : ScriptableObject
	{
		public AssetReference locationPrefab;
	}
}