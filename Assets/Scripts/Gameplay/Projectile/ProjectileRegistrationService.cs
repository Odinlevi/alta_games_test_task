using System;
using Gameplay.Interfaces;

namespace Gameplay.Projectile
{
    public class ProjectileRegistrationService : IGameloopEndable
    {
        public Action OnEnd;
        
        public void End()
        {
            OnEnd?.Invoke();            
        }
    }
}