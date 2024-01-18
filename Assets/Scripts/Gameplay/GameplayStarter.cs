using Gameplay.StateMachine;
using Gameplay.StateMachine.States;
using UnityEngine;
using VContainer;

namespace Gameplay
{
    public class GameplayStarter : MonoBehaviour
    {
        [Inject] private GameplayStateMachine _stateMachine;
        
        private void Start()
        {
            _stateMachine.Enter<InitState>();
        }
    }
}