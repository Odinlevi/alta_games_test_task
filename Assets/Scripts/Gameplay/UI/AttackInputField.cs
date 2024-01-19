using System;
using Gameplay.Input;
using UnityEngine;
using UnityEngine.EventSystems;
using VContainer;

namespace Gameplay.UI
{
    public class AttackInputField : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [Inject] private InputData _inputData;

        private void LateUpdate()
        {
            if (!_inputData.TouchedAttackButtonThisFrame) return;
            _inputData.TouchedAttackButtonThisFrame = false;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _inputData.TouchedAttackButtonThisFrame = true;
            _inputData.HoldingAttackButton = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _inputData.HoldingAttackButton = false;
        }        
    }
}