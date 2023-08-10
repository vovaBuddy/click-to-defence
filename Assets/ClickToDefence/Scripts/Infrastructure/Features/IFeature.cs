using Cysharp.Threading.Tasks;

namespace ClickToDefence.Scripts.Infrastructure.Features
{
	public interface IFeature
	{
		public UniTask Init();
		public UniTask Deinit();
		public void Update();
	}
}