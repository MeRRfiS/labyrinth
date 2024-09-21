using UnityEngine;

namespace Labyrinth.Scripts.Inputs
{
    /// <summary>
    /// Handles input for interaction with UI elements
    /// </summary>
    public class UIInputs : Inputs
    {
        private UIInputAction _input;

        [SerializeField] private GameObject _pauseMenu;

        private void Awake()
        {
            _input = new UIInputAction();

            _input.UI.Pause.performed += x => EnablePauseWindow();
            _input.UI.Pause.canceled += x => EnablePauseWindow();
        }

        /// <summary>
        /// Make Pause Window active, if input is not block
        /// </summary>
        private void EnablePauseWindow()
        {
            if (_isBlock) return;
                
            _pauseMenu.SetActive(true);
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
