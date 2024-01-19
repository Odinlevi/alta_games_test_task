using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Gameplay.Projectile
{
    public class ProjectileFactory : MonoBehaviour
    {
        [SerializeField] private ProjectileBall _projectilePrefab;
        [Inject] private LifetimeScope _currentScope;

        public ProjectileBall GetProjectile(Transform launchPoint)
        {
            var projectile = Instantiate(_projectilePrefab, launchPoint.position, launchPoint.rotation);
            _currentScope.Container.Inject(projectile);
            return projectile;
        }
    }
}