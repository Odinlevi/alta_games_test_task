using Gameplay.StateMachine;
using Gameplay.StateMachine.States;
using UnityEngine;
using VContainer;

namespace Gameplay.Shooter
{
    public class ShooterHealthObserver : MonoBehaviour
    {
        [SerializeField] private float _minimalHealth = 0.1f;
        
        [Inject] private ShooterBallData _shooterBallData;
        [Inject] private GameplayStateMachine _gameplayStateMachine;

        private float _lastHealth;
        
        private void Update()
        {
            if (_shooterBallData.Health <= _minimalHealth && _lastHealth > _minimalHealth)
            {
                _gameplayStateMachine.Enter<EndLoseState>();
            }

            _lastHealth = _shooterBallData.Health;
        }
    }
}