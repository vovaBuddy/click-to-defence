using System;

namespace ClickToDefence.Scripts.Infrastructure.Reactive
{
	public class ReactiveData<T>
	{
		private T val;
		private event Action<T> callbacks;

		public T Value
		{
			get => val;
			set
			{
				val = value;
				callbacks?. Invoke(val);
			}
		}

		public void Subscribe(Action<T> callback, bool invokeOnSubscription)
		{
			callbacks += callback;
		
			if (invokeOnSubscription) {
				callback.Invoke(Value);
			}
		}

		public void Unsubscribe(Action<T> callback)
		{
			callbacks -= callback;
		}
	}
}