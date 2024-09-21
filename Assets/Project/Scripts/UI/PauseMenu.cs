using UnityEngine;
using UnityEngine.UI;

namespace Labyrinth.Scripts.UI
{
    /// <summary>
    /// Window that contain information about pause game
    /// </summary>
	public class PauseMenu : UIMenu
	{
        [SerializeField] private Button _continueButton;
        [SerializeField] private Button _quitButton;

        protected override void OnEnable()
        {
             base.OnEnable();

            _continueButton.onClick.AddListener(DisableMenu);
            _quitButton.onClick.AddListener(OnQuit);

            Time.timeScale = 0;
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            _continueButton.onClick.RemoveListener(DisableMenu);
            _quitButton.onClick.RemoveListener(OnQuit);

            Time.timeScale = 1;
        }

        /// <summary>
        /// Makes Pause window not active
        /// </summary>
        private void DisableMenu()
        {
            gameObject.SetActive(false);
        }
    } 
}
