using Gameplay.Interfaces;
using Gameplay.Shooter;
using UnityEngine;
using VContainer;

namespace Gameplay.Projectile
{
    public class ProjectileMoveService : IGameloopSwitchable
    {
        [Inject] private ShooterBall _shooterBall;
        
        public bool Enable { private get; set; }
        
        public Vector3 CalculateMovementVelocity(ProjectileBall projectileBall, Vector3 direction, float projectileSpeed)
        {
            if (!Enable) return Vector3.zero;

            if (!Input.GetMouseButton(0)) return direction * (Time.fixedDeltaTime * projectileSpeed);
            if (_shooterBall.CurrentProjectileBall == null) return direction * (Time.fixedDeltaTime * projectileSpeed);
            
            if (_shooterBall.CurrentProjectileBall == projectileBall) return Vector3.zero;

            return direction * (Time.fixedDeltaTime * projectileSpeed);
        }
    }
}