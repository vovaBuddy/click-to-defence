using UnityEngine;
using UnityEngine.AddressableAssets;

namespace ClickToDefence.Scripts.Configs
{
	
	[CreateAssetMenu(menuName = "ClickToService/Configs/App config", fileName = "AppConfig", order = 0)]
	public class AppConfig : ScriptableObject
	{
		public static readonly string AssetReferenceKey = "AppConfig";

		public AssetReference camera;
		public AssetReference uiView;
	}
}