using UnityEngine;

namespace Labyrinth.Scripts.Traps.KillObjects
{
    public class Projectile: KillObject
    {
        private const string Cannon = "Cannon";

        protected override void OnTriggerEnter(Collider other)
        {
            base.OnTriggerEnter(other);

            if (!other.name.Contains(Cannon))
            {
                Destroy(gameObject);
            }
        }
    }
}
