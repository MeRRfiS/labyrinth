using UnityEngine;

namespace Labyrinth.Scripts.Traps.KillObjects
{
    /// <summary>
    /// Class for press' spike object
    /// </summary>
    public class Spike: KillObject
    {
        protected override void OnTriggerEnter(Collider other)
        {
            base.OnTriggerEnter(other);
        }
    }
}
