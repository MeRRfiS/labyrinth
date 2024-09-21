using UnityEngine;

namespace Labyrinth.Scripts.Player
{
    /// <summary>
    /// Controls player rotation
    /// </summary>
    public class Rotate : MonoBehaviour
    {
        [SerializeField] private float _sensitivity = 15f;
        private float xRotation = 0f;

        private const float MaxRotationX = 90;
        private const float MinRotationX = -90;

        /// <summary>
        /// Applies rotation to the player and camera based on input values
        /// </summary>
        public void ApplyRotate(Vector2 value)
        {
            float mouseX = value.x * _sensitivity * Time.deltaTime;
            float mouseY = value.y * _sensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, MinRotationX, MaxRotationX);

            Camera.main.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
            transform.Rotate(Vector3.up * mouseX);
        }
    } 
}
