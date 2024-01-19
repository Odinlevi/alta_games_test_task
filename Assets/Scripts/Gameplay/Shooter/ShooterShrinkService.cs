using System;
using Gameplay.Input;
using Gameplay.Interfaces;
using UnityEngine;
using VContainer;

namespace Gameplay.Shooter
{
    public class ShooterShrinkService : IGameloopInitable, IGameloopSwitchable
    {
        private const float ShrinkSpeed = 0.1f;
        
        public bool Enable { private get; set; }
        
        [Inject] private InputData _inputData; 

        public Vector3 GetShrinkedScale(Vector3 scale, float minimalScale)
        {
            if (!Enable)
            {
                return scale;
            }
            
            if (scale.x <= minimalScale)
            {
                return scale;
            }
            
            if (_inputData.HoldingAttackButton)
            {
                return scale - Vector3.one * (ShrinkSpeed * Time.fixedDeltaTime);
                
            }

            return scale;
        }

        public Action OnInit { get; set; }
        public void Init()
        {
            OnInit?.Invoke();
        }
    }
}