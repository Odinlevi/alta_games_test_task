using System;
using Gameplay.Shooter;
using UnityEngine;
using VContainer;

namespace Gameplay.Doors
{
    public class DoorsOpener : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private TriggerHandler _triggerHandler;
        
        private static readonly int Open = Animator.StringToHash("Open");
        private static readonly int Reset = Animator.StringToHash("Reset");
        
        [Inject] private DoorsService _doorsService;

        private bool _isOpened;

        private void Awake()
        {
            _doorsService.OnInit += Initialize;
            _triggerHandler.OnEnter += OnTrigger;
        }
        
        private void Initialize()
        {
            _animator.SetTrigger(Reset);
            _isOpened = false;
        }
        
        private void OnTrigger(Collider other)
        {
            if (_isOpened)
            {
                return;
            }
            
            if (other.TryGetComponent(out ShooterBall _))
            {
                _isOpened = true;
                _animator.ResetTrigger(Reset);
                _animator.SetTrigger(Open);
            }
        }
    }
}