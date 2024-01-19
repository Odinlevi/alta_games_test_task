using Gameplay.Obstacle;
using UnityEngine;
using VContainer;

namespace Gameplay.Projectile
{
    [RequireComponent(typeof(CollisionHandler))]
    public class ProjectileBall : MonoBehaviour
    {
        [SerializeField] private BlowUpArea _blowUpArea;
        [SerializeField] private float _blowUpRadiusCoefficient = 2.5f;

        [SerializeField] private float _projectileSpeed = 500;

        private Rigidbody _rigidbody;

        [Inject] private ProjectileGrowService _projectileGrowService;
        [Inject] private ProjectileMoveService _projectileMoveService;
        [Inject] private ProjectileRegistrationService _projectileRegistrationService;

        [Inject] private BlowUpAreaFadeService _blowUpAreaFadeService;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            GetComponent<CollisionHandler>().OnEnter += OnCollision;
            _projectileRegistrationService.OnEnd += ProjectileDestroy;
        }

        private void FixedUpdate()
        {
            _rigidbody.velocity =
                _projectileMoveService.CalculateMovementVelocity(this, Vector3.right, _projectileSpeed);

            transform.localScale = _projectileGrowService.GetGrownScale(this);
        }

        private void OnCollision(Collision collision)
        {
            if (!collision.gameObject.TryGetComponent(out ObstacleObject _)) return;

            var blowUpRadius = transform.localScale.x * _blowUpRadiusCoefficient;
            
            _blowUpArea.gameObject.SetActive(true);
            _blowUpArea.transform.SetParent(transform.parent);
            _blowUpArea.Initialize(_blowUpAreaFadeService, blowUpRadius);
            
            var colliders = Physics.OverlapSphere(transform.position, blowUpRadius);
            
            foreach (var col in colliders)
            {
                if (col.TryGetComponent(out ObstacleObject obstacleObject))
                {
                    obstacleObject.Infect();
                }
            }
            
            Destroy(gameObject);
        }
        
        private void OnDestroy()
        {
            _projectileRegistrationService.OnEnd -= ProjectileDestroy;
        }
        
        private void ProjectileDestroy()
        {
            Destroy(gameObject);
        }
    }
}