﻿using System;
using Gameplay.Interfaces;
using VContainer;

namespace Gameplay.Shooter
{
    public class ObstacleDetectorShrinkingService : IGameloopInitable, IGameloopSwitchable
    {
        [Inject] private ShooterBall _shooterBall;
        
        public bool Enable { private get; set; }
        
        public float GetShrinkedRadius(float currentRadius, float detectorToShooterCoefficient)
        {
            if (!Enable)
            {
                return currentRadius;
            }
            
            return _shooterBall.transform.localScale.z * detectorToShooterCoefficient; 
            
            // if (Input.GetMouseButton(0))
            // {
            //     return currentRadius - (baseRadius - minimalRadius) * Time.fixedDeltaTime * ShrinkSpeed;
            // }
        }

        public Action OnInit { get; set; }
        
        public void Init()
        {
            OnInit?.Invoke();
        }
    }
}