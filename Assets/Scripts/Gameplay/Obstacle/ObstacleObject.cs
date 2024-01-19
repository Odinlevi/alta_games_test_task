using System;
using System.Collections;
using UnityEngine;
using VContainer;

namespace Gameplay.Obstacle
{
    [RequireComponent(typeof(CollisionHandler))]
    public class ObstacleObject : MonoBehaviour
    {
        [SerializeField] private Renderer _renderer;
        [SerializeField] private Collider _collider;
        [SerializeField] private ParticleSystem _particleSystem;
        
        [SerializeField] private Color _initialColor;
        [SerializeField] private Color _infectedColor;
        [SerializeField] private float _infectionSpeed;
        
        [Inject] private ObstacleColorService _obstacleColorService;
        private bool _isInfected;
        private float _infectionProgress;
        
        public void Enable()
        {
            _renderer.enabled = true;
            _collider.enabled = true;
            _isInfected = false;
            _infectionProgress = 0;
            _renderer.material.color = _initialColor;
        }

        public void Infect()
        {
            _isInfected = true;
            _collider.enabled = false;
        }

        private void Update()
        {
            var (progress, color) = _obstacleColorService.CalculateCurrentColor(_renderer.material.color,
                _infectedColor, _infectionProgress, _infectionSpeed, _isInfected);
            _infectionProgress = progress;
            _renderer.material.color = color;
            
            if (_isInfected && _infectionProgress >= _infectionSpeed)
            {
                BlowUp();
                _isInfected = false;
            }
        }

        public void BlowUp()
        {
            _renderer.enabled = false;
            _particleSystem.Play();
        }
    }
}