using System;
using UnityEngine;

namespace Gameplay
{
    public class TriggerHandler : MonoBehaviour
    {
        
        public Action<Collider> OnEnter;
        
        public void OnTriggerEnter(Collider other)
        {
            OnEnter?.Invoke(other);
        }
        
        public Action<Collider> OnExit;
        public void OnTriggerExit(Collider other)
        {
            OnExit?.Invoke(other);
        }
    }
}