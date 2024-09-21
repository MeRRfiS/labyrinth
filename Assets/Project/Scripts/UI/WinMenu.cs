using UnityEngine;
using UnityEngine.UI;

namespace Labyrinth.Scripts.UI
{
    public class WinMenu : UIMenu
    {
        [SerializeField] private Button _resetButton;
        [SerializeField] private Button _quitButton;

        private void Awake()
        {
            _gameManager.OnWin += EnableWindow;
            gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            _resetButton.onClick.AddListener(OnResetGame);
            _quitButton.onClick.AddListener(OnQuit);
        }

        private void OnDisable()
        {
            _resetButton.onClick.RemoveListener(OnResetGame);
            _quitButton.onClick.RemoveListener(OnQuit);
        }
    } 
}
