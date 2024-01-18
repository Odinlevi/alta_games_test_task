using Gameplay.Interfaces;
using UnityEngine;

namespace Gameplay.Shooter
{
    public class ShooterMoveService : IGameloopSwitchable
    {
        private const float Impulse = 2.5f;
        private readonly Vector3 _direction = new (0.5f, 1, 0);
        
        public bool Enable { private get; set; }
        
        public void CalculateMovement(Rigidbody rigidbody)
        {
            var isGrounded = Physics.Raycast(rigidbody.transform.position, Vector3.down, 
                rigidbody.transform.localScale.y / 2 + 0.1f,
                layerMask: 1 ,queryTriggerInteraction: QueryTriggerInteraction.Ignore);
            
            if (isGrounded)
            {
                rigidbody.velocity = Vector3.zero;
            }
            
            if (!Enable)
            {
                return;
            }

            if (Input.GetMouseButton(0))
            {
                return;
            }
            
            if (isGrounded)
            {
                rigidbody.AddForce(_direction * Impulse, ForceMode.Impulse);
            }
        }
    }
}