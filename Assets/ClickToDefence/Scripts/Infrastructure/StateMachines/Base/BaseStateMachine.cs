using System;
using System.Collections.Generic;

namespace ClickToDefence.Scripts.Infrastructure.StateMachines.Base
{
	public class BaseStateMachine<TState> : IStateMachine where TState : BaseState
	{
		private Dictionary<Type, TState> states;
		private TState activeState;

		public virtual void Init(Dictionary<Type, TState> states, Type startState)
		{
			this.states = states;
			ChangeState(startState);
		}
		
		void IStateMachine.ChangeState<TNewState>()
		{
			var newState = states[typeof(TNewState)];

			ChangeState(newState);
		}

		internal void ChangeState(Type type)
		{
			var newState = states[type];
			
			ChangeState(newState);
		}

		private void ChangeState(TState baseState)
		{
			activeState?.OnExit();
			activeState = baseState;
			activeState.OnEnter();
		}


	}
}