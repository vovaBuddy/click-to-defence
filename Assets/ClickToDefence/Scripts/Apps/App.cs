using System;
using System.Collections.Generic;
using ClickToDefence.Scripts.Apps.States;
using ClickToDefence.Scripts.Infrastructure.DependenciesContainers;
using ClickToDefence.Scripts.Infrastructure.Services;
using ClickToDefence.Scripts.Infrastructure.StateMachines.AppFlow;
using UnityEngine;

namespace ClickToDefence.Scripts.Apps
{
    public class App : MonoBehaviour
    {
        private AppFlowStateMachine appFlowStateMachine = new AppFlowStateMachine();
        private DependenciesContainer<IService> services = new DependenciesContainer<IService>();
        
        void Awake()
        {
            appFlowStateMachine.Init(new Dictionary<Type, AppFlowState>() {
                
                {typeof(BootstrapAppFlowState), new BootstrapAppFlowState(appFlowStateMachine, services)},
                {typeof(CoreGameplayAppFlowState), new CoreGameplayAppFlowState(appFlowStateMachine, services)},
                
            }, typeof(BootstrapAppFlowState));
        }

        private void Update()
        {
            appFlowStateMachine.activeState.Update();
        }
    }
}
