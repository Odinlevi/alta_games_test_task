using System;
using Gameplay.Interfaces;

namespace Gameplay.Doors
{
    public class DoorsService : IGameloopInitable
    {
        public Action OnInit;

        public void Init()
        {
            OnInit?.Invoke();
        }
    }
}