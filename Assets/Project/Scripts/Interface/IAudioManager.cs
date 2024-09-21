using FMOD.Studio;
using FMODUnity;
using Labyrinth.ScriptableObjects;

namespace Labyrinth.Scripts.Interfaces
{
    /// <summary>
    /// Interface for managing audio in the game using FMOD
    /// </summary>
    public interface IAudioManager
	{
        /// <summary>
        /// Gets the FMOD events for the game
        /// </summary>
        public FMODEvents FMODEvents { get; }

        /// <summary>
        /// Creates a new instance of an FMOD event using the provided event reference
        /// </summary>
        public EventInstance CreateInstance(EventReference eventReference);
    } 
}
