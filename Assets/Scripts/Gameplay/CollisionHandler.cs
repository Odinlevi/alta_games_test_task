using System;
using UnityEngine;

namespace Gameplay
{
    public class CollisionHandler : MonoBehaviour
    {
        public Action<Collision> OnEnter { get; set; } 
        
        public void OnCollisionEnter(Collision other)
        {
            OnEnter?.Invoke(other);
        }
        
        public Action<Collision> OnExit { get; set; }
        
        public void OnCollisionExit(Collision other)
        {
            OnExit?.Invoke(other);
        }
    }
}