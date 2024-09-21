using System;
using TMPro;
using UnityEngine;

namespace Labyrinth.Scripts.UI
{
    /// <summary>
    /// Window that contain main information about game
    /// </summary>
    public class GameMenu : UIMenu
    {
        [SerializeField] private TextMeshProUGUI _keyCounter;
        [SerializeField] private TextMeshProUGUI _timer;
        private string _ñounterTextSample;
        private string _timerSample;

        private void Awake()
        {
            _gameManager.OnKeyValueUpdate += UpdateKeyCounterText;
            _gameManager.OnTimerUpdate += UpdateTimerText;

            _ñounterTextSample = _keyCounter.text;
            _timerSample = _timer.text;
        }

        /// <summary>
        /// Updates text of amount of found keys and max amount key
        /// </summary>
        private void UpdateKeyCounterText(int foundKey, int maxKey)
        {
            _keyCounter.text = String.Format(_ñounterTextSample, foundKey, maxKey);
        }

        /// <summary>
        /// Updates text of timer
        /// </summary>
        private void UpdateTimerText(int second)
        {
            _timer.text = String.Format(_timerSample, second);
        }

        private void OnDestroy()
        {
            _gameManager.OnKeyValueUpdate -= UpdateKeyCounterText;
            _gameManager.OnTimerUpdate -= UpdateTimerText;
        }
    } 
}
