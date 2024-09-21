using UnityEngine;

namespace Labyrinth.Scripts.Player
{
    /// <summary>
    /// Camera follows player and turn on when game is end
    /// </summary>
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
