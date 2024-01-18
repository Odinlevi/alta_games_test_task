using System;
using Gameplay.Finish;
using Gameplay.Interfaces;
using Gameplay.Shooter;
using UnityEngine;
using VContainer;

namespace Gameplay.Way
{
    public class WayShrinkService : IGameloopInitable, IGameloopSwitchable
    {
        [Inject] private ShooterBall _shooterBall;
        [Inject] private FinishObject _finishObject;
        
        private const float AdditionalScaleX = 1.5f;
        
        public bool Enable { private get; set; }
        
        public Vector3 GetShrinkedScale(Vector3 currentScale)
        {
            if (!Enable)
            {
                return currentScale;
            }

            var newScaleX = Mathf.Abs(_shooterBall.transform.position.x - _finishObject.transform.position.x) +
                            AdditionalScaleX;

            return new Vector3(newScaleX, currentScale.y, _shooterBall.transform.localScale.z);
        }
        
        public Vector3 GetNewPosition(Vector3 currentPosition)
        {
            if (!Enable)
            {
                return currentPosition;
            }
            
            var newPositionX = (_shooterBall.transform.position.x + _finishObject.transform.position.x) / 2;
            
            return new Vector3(newPositionX, currentPosition.y, currentPosition.z);
        }

        public Action OnInit { get; set; }
        public void Init()
        {
            OnInit?.Invoke();
        }
    }
}