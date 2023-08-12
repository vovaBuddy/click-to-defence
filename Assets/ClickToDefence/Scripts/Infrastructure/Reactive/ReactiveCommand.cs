using System;

namespace ClickToDefence.Scripts.Infrastructure.Reactive
{
	public class ReactiveCommand
	{
		private event Action callbacks;

		public void Subscribe(Action action)
		{
			callbacks += action;
		}

		public void Unsubscribe(Action action)
		{
			callbacks -= action;
		}

		public void Invoke()
		{
			callbacks?.Invoke();
		}
	}
}