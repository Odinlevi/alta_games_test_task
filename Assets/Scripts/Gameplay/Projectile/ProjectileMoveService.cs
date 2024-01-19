using Gameplay.Input;
using Gameplay.Interfaces;
using Gameplay.Shooter;
using UnityEngine;
using VContainer;

namespace Gameplay.Projectile
{
    public class ProjectileMoveService : IGameloopSwitchable
    {
        [Inject] private ShooterBallData _shooterBallData;
        [Inject] private InputData _inputData;
        
        public bool Enable { private get; set; }
        
        public Vector3 CalculateMovementVelocity(ProjectileBall projectileBall, Vector3 direction, float projectileSpeed)
        {
            if (!Enable) return Vector3.zero;

            if (!_inputData.HoldingAttackButton) return direction * (Time.fixedDeltaTime * projectileSpeed);
            if (_shooterBallData.CurrentProjectileBall == null) return direction * (Time.fixedDeltaTime * projectileSpeed);
            
            if (_shooterBallData.CurrentProjectileBall == projectileBall) return Vector3.zero;

            return direction * (Time.fixedDeltaTime * projectileSpeed);
        }
    }
}