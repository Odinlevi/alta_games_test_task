using Gameplay.Interfaces;
using Gameplay.UI;
using UnityEngine;

namespace Gameplay.StateMachine.States
{
    public class EndWinState: EndState
    {
        private readonly GameplayUIController _gameplayUIController;
        
        public EndWinState(GameplayUIController gameplayUIController,
            params IGameloopEndable[] endables) : base(endables)
        {
            _gameplayUIController = gameplayUIController;
        }
        
        public override void Enter()
        {
            base.Enter();
            _gameplayUIController.OnWin();
            Debug.Log("End Win");
        }
    }
}