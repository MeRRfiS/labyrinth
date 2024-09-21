using FMODUnity;
using UnityEngine;
using Zenject;

namespace Labyrinth.Scripts.Traps
{
    /// <summary>
    /// Class for cannon
    /// </summary>
	public class Cannon : Trap
	{
        [Header("Cannon Fields")]
        [SerializeField] private GameObject _projectilePrefab;
        [SerializeField] private Transform _firePoint;
        [SerializeField] private float _projectileSpeed = 20f;

        [Inject] private DiContainer _container;

        protected override void Act()
        {
            var soundEvent = _audioManager.CreateInstance(_audioManager.FMODEvents.Cannon);
            soundEvent.set3DAttributes(RuntimeUtils.To3DAttributes(gameObject));
            soundEvent.start();

            GameObject projectile = _container.InstantiatePrefab(_projectilePrefab);
            projectile.transform.position = _firePoint.position;
            projectile.transform.rotation = _firePoint.rotation;

            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = _firePoint.forward * _projectileSpeed;
            }
        }
    } 
}
