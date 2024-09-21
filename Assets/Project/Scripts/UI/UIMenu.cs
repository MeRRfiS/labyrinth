using Labyrinth.Scripts.Interfaces;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Labyrinth.Scripts.UI
{
    /// <summary>
    /// Base class for UI window
    /// </summary>
    public class UIMenu : MonoBehaviour
    {
        protected IGameManager _gameManager;

        protected void EnableWindow() => gameObject.SetActive(true);

        [Inject]
        private void Construct(IGameManager gameManager)
        {
            _gameManager = gameManager;
        }

        protected virtual void OnEnable()
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        protected virtual void OnDisable()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        /// <summary>
        /// Reset game to start state
        /// </summary>
        protected void OnResetGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        /// <summary>
        /// Close the game
        /// </summary>
        protected void OnQuit()
        {
            Application.Quit();
        }
    } 
}
