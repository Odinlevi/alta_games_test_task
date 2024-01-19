using Gameplay.Projectile;
using UnityEngine;
using VContainer;

namespace Gameplay.Shooter
{
    public class ShooterBall : MonoBehaviour
    {
        [SerializeField] private Transform _launchPoint;
        [SerializeField] private float _minimalScale = 0.1f;
        
        private Vector3 _initialPosition;
        private Rigidbody _rigidbody;

        [Inject] private ShooterShrinkService _shooterShrinkService;
        [Inject] private ShooterMoveService _shooterMoveService;
        
        [Inject] private ProjectileResolverService _projectileResolverService;
        
        [Inject] private ShooterBallData _shooterBallData;
        
        private void Awake()
        {
            _initialPosition = transform.position;
            _rigidbody = GetComponent<Rigidbody>();
            _shooterShrinkService.OnInit += Initialize;
        }
        
        private void Initialize()
        {
            transform.position = _initialPosition;
            transform.localScale = Vector3.one;
            
            _rigidbody.velocity = Vector3.zero;
            
            _shooterBallData.Health = 1;
            _shooterBallData.Transform = transform;
        }

        private void Update()
        {
            _shooterBallData.CurrentProjectileBall =
                _projectileResolverService.Resolve(_shooterBallData.CurrentProjectileBall, _launchPoint);
        }

        private void FixedUpdate()
        {
            transform.localScale = _shooterShrinkService.GetShrinkedScale(transform.localScale, _minimalScale);
            _shooterMoveService.CalculateMovement(_rigidbody);
            
            _shooterBallData.Health = transform.localScale.x;
        }
    }
}