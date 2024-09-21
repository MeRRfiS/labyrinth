using Labyrinth.Scripts.Interfaces;
using UnityEngine;
using Zenject;

namespace Labyrinth.Scripts.Traps.KillObjects
{
    /// <summary>
    /// Base class for objects that kills player
    /// </summary>
	public class KillObject : MonoBehaviour
	{
        protected IGameManager _gameManager;

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

        protected virtual void OnTriggerEnter(Collider other)
        {
            if(IsPlayer(other))
            {
                _gameManager.LoseGame();
                other.gameObject.SetActive(false);
            }
        }
    } 
}
