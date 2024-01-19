using System;
using Gameplay.Interfaces;

namespace Gameplay.Obstacle
{
    public class ObstacleEnableService : IGameloopInitable
    {
        public Action OnInit;
        public void Init()
        {
            OnInit?.Invoke();
        }
        
        public void EnableObstacles(ObstacleObject[] obstacles)
        {
            foreach (var obstacle in obstacles)
            {
                obstacle.Enable();
            }
        }
    }
}