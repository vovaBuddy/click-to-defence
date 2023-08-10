using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace ClickToDefence.Scripts.Infrastructure.Services.Content
{
	public class ContentService : IService
	{
		public async UniTask<T> SpawnAsync<T>(AssetReference reference, Transform parent)
		{
			var go = await Addressables.InstantiateAsync(reference.RuntimeKey, parent).ToUniTask();
			return go.GetComponent<T>();
		}

		public async UniTask<T> LoadAsync<T>(AssetReference reference)
		{
			return await Addressables.LoadAssetAsync<T>(reference);
		}
		
		public async UniTask<T> LoadAsync<T>(string key)
		{
			return await Addressables.LoadAssetAsync<T>(key);
		}

		public void Releace(GameObject gameObject)
		{
			Addressables.ReleaseInstance(gameObject);
		}
	}
}