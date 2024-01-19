using Gameplay.StateMachine;
using Gameplay.StateMachine.States;
using TMPro;
using UnityEngine;
using VContainer;

namespace Gameplay.UI
{
    public class EndPanel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _endText;
        
        [Inject] private GameplayStateMachine _gameplayStateMachine;

        public void OnWin()
        {
            _endText.text = "You win";
        }
        
        public void OnLose()
        {
            _endText.text = "You lose";
        }
        
        public void OnRestartButton()
        {
            _gameplayStateMachine.Enter<InitState>();
            
            gameObject.SetActive(false);
        }
    }
}