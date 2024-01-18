using Gameplay.Interfaces;
using Gameplay.Shooter;
using UnityEngine;
using VContainer;

namespace Gameplay.Projectile
{
    public class ProjectileGrowService : IGameloopSwitchable
    {
        private const float GrowSpeed = 0.2f;
        [Inject] private ShooterBall _shooterBall;
        
        public bool Enable { private get; set; }
        
        public Vector3 GetGrownScale(ProjectileBall projectileBall)
        { 
            if (!Enable)
            {
                return projectileBall.transform.localScale;
            }
            
            if (_shooterBall.transform.localScale.x <= 0.1f)
            {
                return projectileBall.transform.localScale;
            }

            if (_shooterBall.CurrentProjectileBall == null) return projectileBall.transform.localScale;
            if (_shooterBall.CurrentProjectileBall != projectileBall) return projectileBall.transform.localScale;
            
            if (Input.GetMouseButton(0))
            {
                return projectileBall.transform.localScale + Vector3.one * (Time.deltaTime * GrowSpeed);
            }

            return projectileBall.transform.localScale;
        }
    }
}