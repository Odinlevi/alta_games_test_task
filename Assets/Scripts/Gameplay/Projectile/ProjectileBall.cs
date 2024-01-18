using Gameplay.Obstacle;
using UnityEngine;

namespace Gameplay.Projectile
{
    [RequireComponent(typeof(CollisionHandler))]
    public class ProjectileBall : MonoBehaviour
    {
        [SerializeField] private BlowUpArea _blowUpArea;
        [SerializeField] private float _blowUpRadiusCoefficient = 2.5f;

        [SerializeField] private float _projectileSpeed = 500;

        private Rigidbody _rigidbody;

        private ProjectileGrowService _projectileGrowService;
        private ProjectileMoveService _projectileMoveService;

        private BlowUpAreaFadeService _blowUpAreaFadeService;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            GetComponent<CollisionHandler>().OnEnter += OnCollision;
        }

        public void Initialize(ProjectileGrowService projectileGrowService,
            ProjectileMoveService projectileMoveService,
            BlowUpAreaFadeService blowUpAreaFadeService)
        {
            _projectileGrowService = projectileGrowService;
            _projectileMoveService = projectileMoveService;
            _blowUpAreaFadeService = blowUpAreaFadeService;
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
            
            _blowUpArea.Initialize(_blowUpAreaFadeService, blowUpRadius);
            _blowUpArea.gameObject.SetActive(true);
            _blowUpArea.transform.SetParent(transform.parent);
            
            var colliders = Physics.OverlapSphere(transform.position, blowUpRadius);
            
            foreach (var col in colliders)
            {
                if (col.TryGetComponent(out ObstacleObject obstacleObject))
                {
                    obstacleObject.BlowUp();
                }
            }
            
            Destroy(gameObject);
        }
    }
}