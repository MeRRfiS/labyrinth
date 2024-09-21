using UnityEngine;

namespace Labyrinth.Scripts.Player
{
    public class EndGameCamera : MonoBehaviour
    {
        [SerializeField] private Transform _player;

        private void LateUpdate()
        {
            if (_player != null)
            {
                transform.position = new Vector3(_player.position.x, transform.position.y, _player.position.z);
            }
        }
    } 
}
