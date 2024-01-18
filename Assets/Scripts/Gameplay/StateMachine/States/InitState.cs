using FiniteStateMachine.Interfaces;
using Gameplay.Interfaces;
using UnityEngine;

namespace Gameplay.StateMachine.States
{
    public class InitState : IState
    {
        private readonly IMachine _stateMachine;
        private readonly IGameloopInitable[] _initables;
        
        public InitState(IMachine stateMachine, params IGameloopInitable[] initables)
        {
            _stateMachine = stateMachine;
            _initables = initables;
        }
        
        public void Enter()
        {
            Debug.Log("Init");
            
            foreach (var initable in _initables)
            {
                initable.Init();
            }
            
            _stateMachine.Enter<GameloopState>();
        }

        public void Exit()
        {
        }
    }
}