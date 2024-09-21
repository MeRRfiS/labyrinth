using UnityEngine;
using UnityEngine.UI;

namespace Labyrinth.Scripts.UI
{
	public class PauseMenu : UIMenu
	{
        [SerializeField] private Button _continueButton;
        [SerializeField] private Button _quitButton;

        private void OnEnable()
        {
            _continueButton.onClick.AddListener(DisableMenu);
            _quitButton.onClick.AddListener(OnQuit);

            Time.timeScale = 0;
        }

        private void OnDisable()
        {
            _continueButton.onClick.RemoveListener(DisableMenu);
            _quitButton.onClick.RemoveListener(OnQuit);

            Time.timeScale = 1;
        }

        private void DisableMenu()
        {
            gameObject.SetActive(false);
        }
    } 
}
