using Labyrinth.Scripts.Interfaces;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Labyrinth.Scripts.Traps
{
    /// <summary>
    /// Base class for traps
    /// </summary>
	public class Trap : MonoBehaviour
	{
		[SerializeField] private int _activateTime = 10;
        private float _timer;

        protected IAudioManager _audioManager;

        [Inject]
        private void Construct(IAudioManager audioManager)
        {
            _audioManager = audioManager;
        }

        private void Update()
        {
            _timer += Time.deltaTime;

            if (_timer > _activateTime)
            {
                _timer = 0;
                Act();
            }
        }

        /// <summary>
        /// Activates the trap once in a while
        /// </summary>
        protected virtual void Act() { }
    } 
}
