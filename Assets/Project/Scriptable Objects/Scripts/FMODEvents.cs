using FMODUnity;
using UnityEngine;

namespace Labyrinth.ScriptableObjects
{
    /// <summary>
    /// Scriptable object that stores all FMOD Events
    /// </summary>
    [CreateAssetMenu(fileName = "FMODEvents", menuName = "Scriptable Objects/Fmod Events")]
    public class FMODEvents : ScriptableObject
    {
        [field: Header("SFX")]
        [field: SerializeField] public EventReference Cannon { get; private set; }
        [field: SerializeField] public EventReference Press { get; private set; }
        [field: SerializeField] public EventReference Walk { get; private set; }
        [field: SerializeField] public EventReference Key { get; private set; }
        [field: SerializeField] public EventReference Collect { get; private set; }

        [field: Header("Music")]
        [field: SerializeField] public EventReference Music { get; private set; }
    } 
}
