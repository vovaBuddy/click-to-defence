using System;
using System.Collections.Generic;
using ClickToDefence.Scripts.CoreGameplay.States;
using ClickToDefence.Scripts.Infrastructure.DependenciesContainers;
using ClickToDefence.Scripts.Infrastructure.Features;
using ClickToDefence.Scripts.Infrastructure.Services;
using ClickToDefence.Scripts.Infrastructure.StateMachines.AppFlow;
using ClickToDefence.Scripts.Infrastructure.StateMachines.Base;
using ClickToDefence.Scripts.Infrastructure.StateMachines.GameFlow;
using Cysharp.Threading.Tasks;

namespace ClickToDefence.Scripts.Apps.States
{
	public class CoreGameplayAppFlowState : AppFlowState
	{
		private readonly GameFlowStateMachine gameFlowStateMachine;
		private readonly DependenciesContainer<IFeature> features;
		
		public CoreGameplayAppFlowState(IStateMachine stateMachine, DependenciesContainer<IService> services)
			: base(stateMachine, services)
		{
			features = new DependenciesContainer<IFeature>();
			gameFlowStateMachine = new GameFlowStateMachine();
		}

		internal override async UniTask OnEnter()
		{
			await gameFlowStateMachine.Init(new Dictionary<Type, GameFlowState>() {
				
				{typeof(BootstrapCoreGameplayGameFlowState), 
					new BootstrapCoreGameplayGameFlowState(gameFlowStateMachine, services, features)},
				
				{typeof(WaveCoreGameplayGameFlowState), 
					new WaveCoreGameplayGameFlowState(gameFlowStateMachine, services, features)},
				
				{typeof(ResultCoreGameplayGameFlowState), 
					new ResultCoreGameplayGameFlowState(gameFlowStateMachine, services, features)},
				
			}, typeof(BootstrapCoreGameplayGameFlowState));
		}

		public override void Update()
		{
			gameFlowStateMachine.activeState.Update();
		}
	}
}