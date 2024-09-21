using FMOD.Studio;
using FMODUnity;
using UnityEngine;

namespace Labyrinth.Scripts.Traps
{
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

        public void OnActDisable()
        {
            _animator.SetBool(IsAct, false);
        }

        public void OnAnimationEnd()
        {
            _isAnimationEnd = true;
        }

        public void OnPlaySound()
        {
            _soundEvent = _audioManager.CreateInstance(_audioManager.FMODEvents.Press);
            _soundEvent.set3DAttributes(RuntimeUtils.To3DAttributes(gameObject));
            _soundEvent.start();
        }
    } 
}
