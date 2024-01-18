using System.Collections;
using UnityEngine;

namespace Gameplay.Obstacle
{
    [RequireComponent(typeof(CollisionHandler))]
    public class ObstacleObject : MonoBehaviour
    {
        [SerializeField] private Renderer _renderer;
        [SerializeField] private Collider _collider;
        [SerializeField] private ParticleSystem _particleSystem;
        
        public void BlowUp()
        {
            _renderer.enabled = false;
            _particleSystem.Play();
            _collider.enabled = false;
            StartCoroutine(DieAfter(_particleSystem.main.duration));
        }
        
        private IEnumerator DieAfter(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            Destroy(gameObject);
        }
    }
}