using Labyrinth.Scripts.Interfaces;
using UnityEngine;
using Zenject;

namespace Labyrinth.Scripts.Items
{
	public class Item : MonoBehaviour
	{
        protected IGameManager _gameManager;
        protected IAudioManager _audioManager;

        private const string Player = "Player";

        protected bool IsPlayer(Collider collider) => collider.tag == Player;

        [Inject]
        private void Construct(IGameManager gameManager,
                               IAudioManager audioManager)
        {
            _gameManager = gameManager;
            _audioManager = audioManager;
        }
    } 
}
