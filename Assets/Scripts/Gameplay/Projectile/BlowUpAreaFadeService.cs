using Gameplay.Interfaces;
using UnityEngine;

namespace Gameplay.Projectile
{
    public class BlowUpAreaFadeService : IGameloopSwitchable
    {
        public bool Enable { get; set; }
        
        public float CalculateFade(float currentFade, float fadeSpeed)
        {
            if (!Enable) return currentFade;
            
            currentFade -= Time.deltaTime * fadeSpeed;
            currentFade = Mathf.Clamp01(currentFade);
            return currentFade;
        }
    }
}