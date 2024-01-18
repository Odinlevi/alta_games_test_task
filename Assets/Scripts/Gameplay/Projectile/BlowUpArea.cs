using UnityEngine;

namespace Gameplay.Projectile
{
    public class BlowUpArea : MonoBehaviour
    {
        [SerializeField] private float _baseFade = 0.5f;
        [SerializeField] private float _fadeSpeed = 1;
        
        private BlowUpAreaFadeService _blowUpAreaFadeService;
        private static readonly int Fade = Shader.PropertyToID("_Fade");
        
        private Material _material;
        private float _currentFade; 

        public void Initialize(BlowUpAreaFadeService blowUpAreaFadeService, float radius)
        {
            _blowUpAreaFadeService = blowUpAreaFadeService;
            transform.localScale = new Vector3(radius, radius, radius);
            _currentFade = _baseFade;
            _material = GetComponent<MeshRenderer>().material;
            
        }

        public void Update()
        {
            _currentFade = _blowUpAreaFadeService.CalculateFade(_currentFade, _fadeSpeed);
            
            Color color = _material.color;
            color.a = _currentFade;
            _material.color = color;
            
            if (_currentFade <= 0.001f)
            {
                Destroy(gameObject);
            }
        }
    }
}