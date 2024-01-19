using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Gameplay.UI
{
    public class GameplayUIController : MonoBehaviour
    {
        [SerializeField] private EndPanel _endPanel;
        [SerializeField] private AttackInputField _attackInputField;

        [Inject] private LifetimeScope _currentScope; 
        
        private void Awake()
        {
            _currentScope.Container.Inject(_attackInputField);
            _currentScope.Container.Inject(_endPanel);
        }

        public void OnWin()
        {
            _endPanel.gameObject.SetActive(true);
            _endPanel.OnWin();
        }
        
        public void OnLose()
        {
            _endPanel.gameObject.SetActive(true);
            _endPanel.OnLose();
        }
    }
}