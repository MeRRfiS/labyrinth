using FMOD.Studio;
using FMODUnity;
using UnityEngine;

namespace Labyrinth.Scripts.Traps
{
    /// <summary>
    /// Class for press
    /// </summary>
	public class Press : Trap
	{
        [Header("Press Fields")]
        [SerializeField] private Animator _animator;
        private bool _isAnimationEnd = true;
        private EventInstance _soundEvent;

        private const string IsAct = "IsAct";

        protected override void Act()
        {
            if(_isAnimationEnd)
            {
                _isAnimationEnd = false;
                _animator.enabled = true;
                _animator.SetBool(IsAct, true);
            }
        }

        /// <summary>
        /// Method for animation event. Triggerd when press return to start position
        /// </summary>
        public void OnActDisable()
        {
            _animator.SetBool(IsAct, false);
        }

        /// <summary>
        /// Method for animation event. Triggerd when animation is end
        /// </summary>
        public void OnAnimationEnd()
        {
            _isAnimationEnd = true;
        }

        /// <summary>
        /// Method for animation event. Play sound when press worked
        /// </summary>
        public void OnPlaySound()
        {
            _soundEvent = _audioManager.CreateInstance(_audioManager.FMODEvents.Press);
            _soundEvent.set3DAttributes(RuntimeUtils.To3DAttributes(gameObject));
            _soundEvent.start();
        }
    } 
}
