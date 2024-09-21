using Labyrinth.Scripts.Interfaces;
using System;
using TMPro;
using UnityEngine;
using Zenject;

namespace Labyrinth.Scripts.UI
{
    public class PlayerMenu : UIMenu
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

        private void UpdateKeyCounterText(int foundKey, int maxKey)
        {
            _keyCounter.text = String.Format(_ñounterTextSample, foundKey, maxKey);
        }

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
