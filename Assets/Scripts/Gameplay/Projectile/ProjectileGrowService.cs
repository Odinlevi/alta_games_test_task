using Gameplay.Input;
using Gameplay.Interfaces;
using Gameplay.Shooter;
using UnityEngine;
using VContainer;

namespace Gameplay.Projectile
{
    public class ProjectileGrowService : IGameloopSwitchable
    {
        private const float GrowSpeed = 0.2f;
        [Inject] private ShooterBallData _shooterBallData;
        [Inject] private InputData _inputData;
        
        public bool Enable { private get; set; }
        
        public Vector3 GetGrownScale(ProjectileBall projectileBall)
        { 
            if (!Enable)
            {
                return projectileBall.transform.localScale;
            }
            
            if (_shooterBallData.Health <= 0.1f)
            {
                return projectileBall.transform.localScale;
            }

            if (_shooterBallData.CurrentProjectileBall == null) return projectileBall.transform.localScale;
            if (_shooterBallData.CurrentProjectileBall != projectileBall) return projectileBall.transform.localScale;
            
            if (_inputData.HoldingAttackButton)
            {
                return projectileBall.transform.localScale + Vector3.one * (Time.deltaTime * GrowSpeed);
            }

            return projectileBall.transform.localScale;
        }
    }
}