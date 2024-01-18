using UnityEngine;
using VContainer;

namespace Gameplay.Camera
{
    public class CameraFollower : MonoBehaviour
    {
        [SerializeField] private Vector3 _baseDistance;
        [Inject] private CameraFollowService _cameraFollowService;
        
        private void Update()
        {
            transform.position = _cameraFollowService.CalculatePosition(transform.position, _baseDistance);
        }
    }
}