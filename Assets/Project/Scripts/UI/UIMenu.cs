using Labyrinth.Scripts.Interfaces;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Labyrinth.Scripts.UI
{
    public class UIMenu : MonoBehaviour
    {
        protected IGameManager _gameManager;

        protected void EnableWindow() => gameObject.SetActive(true);

        [Inject]
        private void Construct(IGameManager gameManager)
        {
            _gameManager = gameManager;
        }

        protected void OnResetGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        protected void OnQuit()
        {
            Application.Quit();
        }
    } 
}
