using Gameplay.Interfaces;
using Gameplay.Shooter;
using UnityEngine;
using VContainer;

namespace Gameplay.Camera
{
    public class CameraFollowService : IGameloopSwitchable
    {
        [Inject] private ShooterBall _shooterBall;
        public bool Enable { get; set; }
        
        public Vector3 CalculatePosition(Vector3 targetPosition, Vector3 distance)
        {
            if (!Enable)
            {
                return targetPosition;
            }
            
            var shooterPos = _shooterBall.transform.position;
            
            return new Vector3(shooterPos.x + distance.x, distance.y, shooterPos.z + distance.z);
        }
    }
}