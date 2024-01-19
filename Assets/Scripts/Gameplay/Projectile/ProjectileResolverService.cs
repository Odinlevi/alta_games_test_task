using Gameplay.Input;
using Gameplay.Interfaces;
using UnityEngine;
using VContainer;

namespace Gameplay.Projectile
{
    public class ProjectileResolverService : IGameloopSwitchable
    {
        [Inject] private ProjectileFactory _projectileFactory;
        [Inject] private InputData _inputData;
        
        public bool Enable { private get; set; }

        public ProjectileBall Resolve(ProjectileBall projectile, Transform launchPoint)
        {
            if (!Enable) return projectile;

            
            if (_inputData.TouchedAttackButtonThisFrame)
            {
                return _projectileFactory.GetProjectile(launchPoint);
            }

            return projectile;
        }
    }
}