using System;
using UnityEngine;
using VContainer;

namespace Gameplay.Way
{
    public class MovingWay : MonoBehaviour
    {
        [Inject] private WayShrinkService _wayShrinkService;
        
        private Vector3 _initScale;
        private Vector3 _initPosition;
        
        private void Start()
        {
            _wayShrinkService.OnInit += Initialize;
            _initScale = transform.localScale;
            _initPosition = transform.position;
        }

        private void Initialize()
        {
            transform.localScale = _initScale;
            transform.position = _initPosition;
        }

        private void FixedUpdate()
        {
            transform.localScale = _wayShrinkService.GetShrinkedScale(transform.localScale);
            transform.position = _wayShrinkService.GetNewPosition(transform.position);
        }
    }
}