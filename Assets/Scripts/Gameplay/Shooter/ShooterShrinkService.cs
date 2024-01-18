using System;
using Gameplay.Interfaces;
using UnityEngine;

namespace Gameplay.Shooter
{
    public class ShooterShrinkService : IGameloopInitable, IGameloopSwitchable
    {
        private const float ShrinkSpeed = 0.1f;
        
        public bool Enable { private get; set; }

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
            
            if (Input.GetMouseButton(0))
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