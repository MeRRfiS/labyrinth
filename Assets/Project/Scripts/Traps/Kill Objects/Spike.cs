using UnityEngine;

namespace Labyrinth.Scripts.Traps.KillObjects
{
    public class Spike: KillObject
    {
        protected override void OnTriggerEnter(Collider other)
        {
            base.OnTriggerEnter(other);
        }
    }
}
