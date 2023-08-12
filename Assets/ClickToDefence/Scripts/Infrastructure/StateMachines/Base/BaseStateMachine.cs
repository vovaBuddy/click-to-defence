using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace ClickToDefence.Scripts.Infrastructure.StateMachines.Base
{
	public class BaseStateMachine<TState> : IStateMachine where TState : BaseState
	{
		private Dictionary<Type, TState> states;
		public TState activeState { get; private set; }

		public virtual async UniTask Init(Dictionary<Type, TState> states, Type startState)
		{
			this.states = states;
			await ChangeState(startState);
		}
		
		async UniTask IStateMachine.ChangeState<TNewState>()
		{
			var newState = states[typeof(TNewState)];

			await ChangeState(newState);
		}

		internal async UniTask ChangeState(Type type)
		{
			var newState = states[type];
			
			await ChangeState(newState);
		}

		private async UniTask ChangeState(TState baseState)
		{
			activeState?.OnExit();
			activeState = baseState;
			await activeState.OnEnter();
		}


	}
}