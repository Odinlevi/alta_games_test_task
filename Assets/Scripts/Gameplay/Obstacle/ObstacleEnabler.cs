using UnityEngine;
using VContainer;

namespace Gameplay.Obstacle
{
    public class ObstacleEnabler : MonoBehaviour
    {
        [SerializeField] private ObstacleObject[] _obstacles;        

        [Inject] private ObstacleEnableService _obstacleEnableService;
        
        private void Awake()
        {
            _obstacleEnableService.OnInit += OnEnableObstacles;
        }
        
        private void OnEnableObstacles()
        {
            _obstacleEnableService.EnableObstacles(_obstacles);
        }
    }
}