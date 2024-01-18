using GlobalServices;
using UnityEngine;
using VContainer;

namespace Boot
{
    public class BootStarter : MonoBehaviour
    {
        [Inject] private SceneLoaderService _sceneLoaderService;
        
        private async void Start()
        {
            await _sceneLoaderService.Load(1);
        }
    }
}