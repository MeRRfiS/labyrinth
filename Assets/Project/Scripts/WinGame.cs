using Labyrinth.Scripts.Interfaces;
using UnityEngine;
using Zenject;

namespace Labyrinth.Scripts
{
    /// <summary>
    /// Class for a game's finish
    /// </summary>
	public class WinGame : MonoBehaviour
	{
        private IGameManager _gameManager;

        private const string Player = "Player";

        /// <summary>
        /// Check tag of object that enter to collider
        /// </summary>
        protected bool IsPlayer(Collider collider) => collider.tag == Player;

        [Inject]
        private void Construct(IGameManager gameManager)
        {
            _gameManager = gameManager;
        }

        private void OnTriggerEnter(Collider other)
        {
            if(IsPlayer(other))
            {
                _gameManager.WinGame();
                other.gameObject.SetActive(false);
            }
        }
    } 
}
