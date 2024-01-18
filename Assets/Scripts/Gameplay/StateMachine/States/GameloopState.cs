using FiniteStateMachine.Interfaces;
using Gameplay.Interfaces;
using Gameplay.Shooter;
using Gameplay.Way;
using UnityEngine;

namespace Gameplay.StateMachine.States
{
    public class GameloopState : IState
    {
        private readonly IGameloopSwitchable[] _switchables;
        
        public GameloopState(params IGameloopSwitchable[] switchables)
        {
            _switchables = switchables;
        }
        
        public void Enter()
        {
            Debug.Log("Gameloop");
            
            Time.timeScale = 1;
            
            foreach (var switchable in _switchables)
            {
                switchable.Enable = true;
            }
        }

        public void Exit()
        {
            
        }
    }
}