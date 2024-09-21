using UnityEngine;

namespace Labyrinth.Scripts.UI
{
    public class UIInputs : MonoBehaviour
    {
        private UIInputAction _input;

        [SerializeField] private GameObject _pauseMenu;

        private void Awake()
        {
            _input = new UIInputAction();

            _input.UI.Pause.performed += x => _pauseMenu.SetActive(true);
            _input.UI.Pause.canceled += x => _pauseMenu.SetActive(true);
        }

        private void Start()
        {
            _input.Enable();
        }

        private void OnDestroy()
        {
            _input.Disable();
        }
    } 
}
