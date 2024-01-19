using Gameplay.Shooter;
using Gameplay.StateMachine;
using Gameplay.StateMachine.States;
using UnityEngine;
using VContainer;

namespace Gameplay.Finish
{
    [RequireComponent(typeof(TriggerHandler))]
    public class FinishTrigger : MonoBehaviour
    {
        [Inject] private GameplayStateMachine _gameplayStateMachine;
        
        private void Awake()
        {
            GetComponent<TriggerHandler>().OnEnter += OnTrigger;
        }

        private void OnTrigger(Collider other)
        {
            if (other.TryGetComponent(out ShooterBall _))
            {
                _gameplayStateMachine.Enter<EndWinState>();
            }
        }
    }
}