using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Gameplay.Projectile
{
    public class ProjectileFactory : MonoBehaviour
    {
        [SerializeField] private ProjectileBall _projectilePrefab;
        [SerializeField] private LifetimeScope _gameloopContainer;
        
        private ProjectileGrowService _projectileGrowService;
        private ProjectileMoveService _projectileMoveService;
        private BlowUpAreaFadeService _blowUpAreaFadeService;

        private void Start()
        {
            _projectileGrowService = _gameloopContainer.Container.Resolve<ProjectileGrowService>();
            _projectileMoveService = _gameloopContainer.Container.Resolve<ProjectileMoveService>();
            _blowUpAreaFadeService = _gameloopContainer.Container.Resolve<BlowUpAreaFadeService>();
        }

        public ProjectileBall GetProjectile(Transform launchPoint)
        {
            var projectile = Instantiate(_projectilePrefab, launchPoint.position, launchPoint.rotation);
            projectile.Initialize(_projectileGrowService, _projectileMoveService, _blowUpAreaFadeService);
            return projectile;
        }
    }
}