using Labyrinth.Scripts.Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;
using Zenject;

namespace Labyrinth.Scripts.Player
{
    [RequireComponent(typeof(Movement), typeof(Rotate))]
    public class PlayerInputs : MonoBehaviour
    {
        private bool _isBlock = false;
        private bool _isRunning = false;
        private Vector2 _movementValue;
        private Vector2 _rotateValue;
        private Movement _movement;
        private Rotate _rotate;
        private PlayerInputAction _input;

        private IGameManager _gameManager;

        private void BlockInput() => _isBlock = true;

        [Inject]
        private void Construct(IGameManager gameManager)
        {
            _gameManager = gameManager;

            _gameManager.OnPlayerDead += BlockInput;
            _gameManager.OnWin += BlockInput;
        }

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

            _gameManager.OnPlayerDead -= BlockInput;
            _gameManager.OnWin -= BlockInput;
        }
    } 
}
