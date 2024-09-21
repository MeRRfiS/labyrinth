using UnityEngine;
using UnityEngine.UI;

namespace Labyrinth.Scripts.UI
{
    /// <summary>
    /// Window that contain information about win game
    /// </summary>
    public class WinMenu : UIMenu
    {
        [SerializeField] private Button _resetButton;
        [SerializeField] private Button _quitButton;

        private void Awake()
        {
            _gameManager.OnWin += EnableWindow;
            gameObject.SetActive(false);
        }

        protected override void OnEnable()
        {
            base.OnEnable();

            _resetButton.onClick.AddListener(OnResetGame);
            _quitButton.onClick.AddListener(OnQuit);
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            _resetButton.onClick.RemoveListener(OnResetGame);
            _quitButton.onClick.RemoveListener(OnQuit);
        }
    } 
}
