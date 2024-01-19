using Gameplay.Interfaces;
using UnityEngine;

namespace Gameplay.Obstacle
{
    public class ObstacleColorService : IGameloopSwitchable
    {
        public bool Enable { get; set; }
        
        public (float, Color) CalculateCurrentColor(Color currentColor, Color targetColor, float currentProgress, float speed, bool isInfected)
        {
            if (!Enable)
            {
                return (currentProgress, currentColor);
            }
            
            if (isInfected)
            {
                return (currentProgress + Time.deltaTime,
                    Color.Lerp(currentColor, targetColor, speed * Time.deltaTime));
            }
            
            return (currentProgress, currentColor);
        }
    }
}