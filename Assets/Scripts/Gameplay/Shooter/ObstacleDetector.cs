using Gameplay.Obstacle;
using UnityEngine;
using VContainer;

namespace Gameplay.Shooter
{
    public class ObstacleDetector : MonoBehaviour
    {
        [Inject] private ShooterMoveService _shooterMoveService;
        
        [Inject] private ObstacleDetectorShrinkingService _obstacleDetectorShrinkingService;
        
        // [SerializeField] private float _baseRadius = 0.5f;
        // [SerializeField] private float _minimalRadius = 0.05f;
        [SerializeField] private Vector3 _detectionDirection = new (2f, 0, 0);
        [SerializeField] private float _detectorToShooterCoefficient = 0.5f;
        
        private float _currentRadius;
        
        private void Awake()
        {
            _obstacleDetectorShrinkingService.OnInit += Initialize;
        }

        private void Initialize()
        {
            _currentRadius = 1 * _detectorToShooterCoefficient;
        }

        private void FixedUpdate()
        {
            _currentRadius =
                _obstacleDetectorShrinkingService.GetShrinkedRadius(_currentRadius, _detectorToShooterCoefficient);
            
            var colliders = Physics.OverlapCapsule(transform.position,
                transform.position + _detectionDirection,
                _currentRadius);

            foreach (var collider in colliders)
            {
                if (collider.TryGetComponent(out ObstacleObject _))
                {
                    _shooterMoveService.Enable = false;
                    return;
                }
            }
            
            _shooterMoveService.Enable = true;
        }
        
        public void OnDrawGizmosSelected()
        {
            var origin = transform.position;

            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(origin, _currentRadius);
            Gizmos.DrawWireSphere(origin + _detectionDirection, _currentRadius);
        }
    }
}