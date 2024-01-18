using Gameplay.Projectile;
using UnityEngine;
using VContainer;

namespace Gameplay.Shooter
{
    public class ShooterBall : MonoBehaviour
    {
        public ProjectileBall CurrentProjectileBall { get; private set; }
        
        [SerializeField] private Transform _launchPoint;
        [SerializeField] private float _minimalScale = 0.1f;
        
        private Vector3 _initialPosition;
        private Rigidbody _rigidbody;
        
        [Inject] private ShooterShrinkService _shooterShrinkService;
        [Inject] private ShooterMoveService _shooterMoveService;
        
        [Inject] private ProjectileResolverService _projectileResolverService;
        
        private void Start()
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
        }

        private void Update()
        {
            CurrentProjectileBall = _projectileResolverService.Resolve(CurrentProjectileBall, _launchPoint);
        }

        private void FixedUpdate()
        {
            transform.localScale = _shooterShrinkService.GetShrinkedScale(transform.localScale, _minimalScale);
            
            if (transform.localScale.x <= _minimalScale)
            {
                Debug.Log("defeat");
            }
            
            _shooterMoveService.CalculateMovement(_rigidbody);
        }
    }
}