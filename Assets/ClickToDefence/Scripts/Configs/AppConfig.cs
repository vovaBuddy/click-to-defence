using ClickToDefence.Scripts.CoreGameplay.Configs;
using ClickToDefence.Scripts.CoreGameplay.Features.Locations.Configs;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace ClickToDefence.Scripts.Configs
{
	
	[CreateAssetMenu(menuName = "ClickToService/Configs/App config", fileName = "AppConfig", order = 0)]
	public class AppConfig : ScriptableObject
	{
		public static readonly string AssetReferenceKey = "AppConfig";

		public CoreGameplayConfig coreGameplayConfig;
		public LocationsConfig locationsConfig;

		public AssetReference camera;
		public AssetReference uiView;
	}
}