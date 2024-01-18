using FiniteStateMachine.Interfaces;
using Gameplay.Interfaces;
using UnityEngine;

namespace Gameplay.StateMachine.States
{
    public class EndState : IState
    {
        private readonly IGameloopEndable[] _endables;
        
        public EndState(params IGameloopEndable[] endables)
        {
            _endables = endables;
        }
        
        public void Enter()
        {
            Debug.Log("End");
            
            foreach (var endable in _endables)
            {
                endable.End();
            }
        }

        public void Exit()
        {
            
        }
    }
}