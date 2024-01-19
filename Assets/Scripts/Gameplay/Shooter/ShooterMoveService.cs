using Gameplay.Input;
using Gameplay.Interfaces;
using UnityEngine;
using VContainer;

namespace Gameplay.Shooter
{
    public class ShooterMoveService : IGameloopInitable, IGameloopSwitchable, IGameloopEndable
    {
        private const float Impulse = 2.5f;
        private readonly Vector3 _direction = new (0.5f, 1, 0);
        
        public bool Enable { private get; set; }
        private bool _inGameloop;
        
        public bool ObstacleDetected { private get; set; }
        
        [Inject] private InputData _inputData;
        
        public void Init()
        {
            _inGameloop = true;
        }
        
        public void End()
        {
            _inGameloop = false;
        }
        
        public void CalculateMovement(Rigidbody rigidbody)
        {
            var isGrounded = Physics.Raycast(rigidbody.transform.position, Vector3.down, 
                rigidbody.transform.localScale.y / 2 + 0.1f,
                layerMask: 1 ,queryTriggerInteraction: QueryTriggerInteraction.Ignore);
            
            if (isGrounded)
            {
                rigidbody.velocity = Vector3.zero;
            }
            
            if (!Enable || ObstacleDetected || !_inGameloop)
            {
                return;
            }

            if (_inputData.HoldingAttackButton)
            {
                rigidbody.velocity = Vector3.down;
                return;
            }
            
            if (isGrounded)
            {
                rigidbody.AddForce(_direction * Impulse, ForceMode.Impulse);
            }
        }
    }
}