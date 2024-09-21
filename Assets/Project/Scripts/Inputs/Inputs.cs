using Labyrinth.Scripts.Interfaces;
using UnityEngine;
using Zenject;

namespace Labyrinth.Scripts.Inputs
{
    /// <summary>
    /// Base class for inputs
    /// </summary>
	public class Inputs : MonoBehaviour
	{
		protected bool _isBlock = false;

        private void BlockInput() => _isBlock = true;

        private IGameManager _gameManager;

        [Inject]
        private void Construct(IGameManager gameManager)
        {
            _gameManager = gameManager;

            _gameManager.OnLose += BlockInput;
            _gameManager.OnWin += BlockInput;
        }
    } 
}
