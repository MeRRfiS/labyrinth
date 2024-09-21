using FMOD.Studio;
using FMODUnity;
using Labyrinth.Scripts.Interfaces;
using UnityEngine;
using Zenject;

namespace Labyrinth.Scripts.Player
{
    /// <summary>
    /// Controls player movement and manages footstep sounds using FMOD
    /// </summary>
    [RequireComponent(typeof(CharacterController))]
	public class Movement : MonoBehaviour
	{
        [SerializeField] private float _speed = 5f;
        [SerializeField] private float _runSpeed = 10f;
        [SerializeField] private float _gravity = 9.8f;

		private CharacterController _chController;
        private EventInstance _walk;

        private const string MovementSpeed = "MovementSpeed";

        private IAudioManager _audioManager;
        private IGameManager _gameManager;

        /// <summary>
        /// Stops the footstep sound immediately
        /// </summary>
        private void StopWalkSound() => _walk.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);

        [Inject]
        private void Construct(IAudioManager audioManager,
                               IGameManager gameManager)
        {
            _audioManager = audioManager;
            _gameManager = gameManager;

            _gameManager.OnLose += StopWalkSound;
            _gameManager.OnWin += StopWalkSound;
        }

        private void Start()
        {
            _chController = GetComponent<CharacterController>();

            _walk = _audioManager.CreateInstance(_audioManager.FMODEvents.Walk);
            _walk.set3DAttributes(RuntimeUtils.To3DAttributes(gameObject));
        }

        /// <summary>
        /// Applies movement to the character based on input values
        /// </summary>
        public void ApplyMovement(Vector2 value, bool isRunning)
        {
            UpdateSound(isRunning);

            Vector3 direction = (transform.right * value.x + transform.forward * value.y) * 
                                (isRunning ? _runSpeed : _speed);
            direction.y = -_gravity * Time.deltaTime;

            _chController.Move(direction * Time.deltaTime);
        }

        /// <summary>
        /// Updates the footstep sound based on the player's movement state (running or walking)
        /// </summary>
        private void UpdateSound(bool isRunning)
        {
            if(_chController.velocity.x != 0 || _chController.velocity.z != 0)
            {
                _walk.getParameterByName(MovementSpeed, out float a);
                Debug.Log(a);
                if (isRunning)
                {
                    _walk.setParameterByName(MovementSpeed, 1f);
                }
                else
                {
                    _walk.setParameterByName(MovementSpeed, 0f);
                }

                PLAYBACK_STATE playbackState;
                _walk.getPlaybackState(out playbackState);
                if (playbackState != PLAYBACK_STATE.PLAYING)
                {
                    _walk.start();
                }
            }
            else
            {
                _walk.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            }
        }

        private void OnDestroy()
        {
            StopWalkSound();
            _gameManager.OnLose -= StopWalkSound; 
            _gameManager.OnWin -= StopWalkSound;
        }
    } 
}
