using Gameplay.Projectile;
using UnityEngine;

namespace Gameplay.Shooter
{
    public class ShooterBallData
    {
        public float Health;
        public Transform Transform;
        
        public ProjectileBall CurrentProjectileBall { get; set; }
    }
}