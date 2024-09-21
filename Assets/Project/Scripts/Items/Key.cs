using FMOD.Studio;
using FMODUnity;
using Labyrinth.Scripts.Interfaces;
using UnityEngine;
using Zenject;

namespace Labyrinth.Scripts.Items
{
	public class Key : Item
    {
        private EventInstance _keySound;

        private void Awake()
        {
            _keySound = _audioManager.CreateInstance(_audioManager.FMODEvents.Key);
            _keySound.set3DAttributes(RuntimeUtils.To3DAttributes(gameObject));
            _keySound.start();
        }

        private void OnTriggerEnter(Collider other)
        {
            if(IsPlayer(other))
            {
                _gameManager.AddKey();

                var collectSound = _audioManager.CreateInstance(_audioManager.FMODEvents.Collect);
                collectSound.start();

                Destroy(gameObject);
            }
        }

        private void OnDestroy()
        {
            _keySound.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        }
    } 
}
