using FMOD.Studio;
using FMODUnity;
using Labyrinth.ScriptableObjects;
using System;

namespace Labyrinth.Scripts.Interfaces
{
	public interface IAudioManager
	{
		public FMODEvents FMODEvents { get; }
		public EventInstance CreateInstance(EventReference eventReference);
    } 
}
