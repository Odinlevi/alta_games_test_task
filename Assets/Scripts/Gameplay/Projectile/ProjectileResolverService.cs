using Gameplay.Interfaces;
using UnityEngine;
using VContainer;

namespace Gameplay.Projectile
{
    public class ProjectileResolverService : IGameloopSwitchable
    {
        [Inject] private ProjectileFactory _projectileFactory;
        
        public bool Enable { private get; set; }

        public ProjectileBall Resolve(ProjectileBall projectile, Transform launchPoint)
        {
            if (!Enable) return projectile;

            
            if (Input.GetMouseButtonDown(0))
            {
                return _projectileFactory.GetProjectile(launchPoint);
            }

            return projectile;
        }
    }
}