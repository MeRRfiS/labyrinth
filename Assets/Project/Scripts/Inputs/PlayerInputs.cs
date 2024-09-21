using Labyrinth.Scripts.Player;
using UnityEngine;

namespace Labyrinth.Scripts.Inputs
{
    /// <summary>
    /// Handles player input for movement and rotation
    /// </summary>
    [RequireComponent(typeof(Movement), typeof(Rotate))]
    public class PlayerInputs : Inputs
    {
        private bool _isRunning = false;
        private Vector2 _movementValue;
        private Vector2 _rotateValue;
        private Movement _movement;
        private Rotate _rotate;
        private PlayerInputAction _input;

        private void Awake()
        {
            _input = new PlayerInputAction();

            _input.Player.Move.performed += x => _movementValue = x.ReadValue<Vector2>();
            _input.Player.Move.canceled += x => _movementValue = Vector2.zero;
            _input.Player.Run.performed += x => _isRunning = true;
            _input.Player.Run.canceled += x => _isRunning = false;

            _input.Player.Rotate.performed += x => _rotateValue = x.ReadValue<Vector2>();
            _input.Player.Rotate.canceled += x => _rotateValue = Vector2.zero;
        }

        private void Start()
        {
            _input.Enable();

            _movement = GetComponent<Movement>();
            _rotate = GetComponent<Rotate>();
        }

        private void Update()
        {
            if (_isBlock) return;

            _movement.ApplyMovement(_movementValue, _isRunning);
            _rotate.ApplyRotate(_rotateValue);
        }
        
        private void OnDestroy()
        {
            _input.Disable();
        }
    } 
}
