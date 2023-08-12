using System;
using System.Collections.Generic;
using ClickToDefence.Scripts.Infrastructure.Reactive;
using UnityEngine;
using UnityEngine.UI;

namespace ClickToDefence.Scripts.Infrastructure.Services.UI
{
	public abstract class UIViewWithModel<TViewModel> : MonoBehaviour
	{
		private TViewModel viewModel;
		
		private List<Action> deconstructActions = new List<Action>(0);

		public virtual void Construct(TViewModel viewModel)
		{
			this.viewModel = viewModel;
		}

		public virtual void Deconstruct()
		{
			foreach (Action action in deconstructActions) {
				action.Invoke();
			}
			
			deconstructActions.Clear();
		}

		protected void Subscribe<T>(ReactiveData<T> data, Action<T> callback)
		{
			data.Subscribe(callback, true);
			deconstructActions.Add(() => data.Unsubscribe(callback));
		}

		protected void Subscribe(ReactiveCommand command, Action callback)
		{
			command.Subscribe(callback);
			deconstructActions.Add(() => command.Unsubscribe(callback));
		}

		protected void Subscribe(Button button, ReactiveCommand command)
		{
			button.onClick.AddListener(command.Invoke);
			deconstructActions.Add(() => button.onClick.RemoveListener(command.Invoke));
		}
	}
}