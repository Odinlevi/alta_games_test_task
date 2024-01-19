using Gameplay.Interfaces;
using Gameplay.UI;
using UnityEngine;

namespace Gameplay.StateMachine.States
{
    public class EndLoseState : EndState
    {
        private readonly GameplayUIController _gameplayUIController;
        public EndLoseState(GameplayUIController gameplayUIController,
            params IGameloopEndable[] endables) : base(endables)
        {
            _gameplayUIController = gameplayUIController;
        }
        
        public override void Enter()
        {
            base.Enter();
            _gameplayUIController.OnLose();
            Debug.Log("End Lose");
        }
    }
}