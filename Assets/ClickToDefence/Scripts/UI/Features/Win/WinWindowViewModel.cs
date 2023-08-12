using ClickToDefence.Scripts.Infrastructure.Reactive;

namespace ClickToDefence.Scripts.UI.Features.Win
{
	public class WinWindowViewModel
	{
		public ReactiveData<bool> isActive = new ReactiveData<bool>();
		public ReactiveData<int> waveNumber = new ReactiveData<int>();
		public ReactiveCommand next = new ReactiveCommand();
	}
}