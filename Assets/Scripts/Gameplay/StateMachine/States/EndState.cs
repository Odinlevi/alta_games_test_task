
using FiniteStateMachine.Interfaces;
using Gameplay.Interfaces;

namespace Gameplay.StateMachine.States
{
    public abstract class EndState : IState
    {
        private readonly IGameloopEndable[] _endables;
        
        public EndState(params IGameloopEndable[] endables) 
        {
            _endables = endables;
        }
        
        public virtual void Enter()
        {
            foreach (var endable in _endables)
            {
                endable.End();
            }
        }

        public virtual void Exit()
        {
            
        }
    }
}