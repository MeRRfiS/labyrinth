using FMOD.Studio;
using FMODUnity;
using Labyrinth.ScriptableObjects;
using Labyrinth.Scripts.Interfaces;
using System;
using UnityEngine;

namespace Labyrinth.Scripts
{
    /// <summary>
    /// Manager for audio in the game using FMOD
    /// </summary>
    public class AudioManager : MonoBehaviour, IAudioManager
    {
        [field: SerializeField] public FMODEvents FMODEvents { get; private set; }

        private EventInstance _music;

        private void Awake()
        {
            _music = CreateInstance(FMODEvents.Music);
            _music.start();
        }

        public EventInstance CreateInstance(EventReference eventReference)
        {
            EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);

            return eventInstance;
        }

        private void OnDestroy()
        {
            _music.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        }
    }
}
