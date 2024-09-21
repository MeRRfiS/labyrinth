using Labyrinth.Scripts.Interfaces;
using UnityEngine;
using Zenject;

namespace Labyrinth.Scripts.Traps.KillObjects
{
	public class KillObject : MonoBehaviour
	{
        protected IGameManager _gameManager;

        private const string Player = "Player";

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
                _gameManager.KillPlayer();
                other.gameObject.SetActive(false);
            }
        }
    } 
}
