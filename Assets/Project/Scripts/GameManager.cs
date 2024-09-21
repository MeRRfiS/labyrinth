using Labyrinth.Scripts.Interfaces;
using Labyrinth.Scripts.Items;
using System;
using UnityEngine;

namespace Labyrinth.Scripts
{
    /// <summary>
    /// Manager for game events and player state
    /// </summary>
	public class GameManager : MonoBehaviour, IGameManager
    {
        [SerializeField] private GameObject _exit;
		private int _maxKeys;
		private int _foundKeys = 0;
        private float _timeInGame = 0;

        public event Action OnLose;
        public event Action OnWin;
        public event Action<int> OnTimerUpdate;
        public event Action<int, int> OnKeyValueUpdate;

        private void Start()
        {
            _maxKeys = FindObjectsByType<Key>(FindObjectsSortMode.None).Length;
            OnKeyValueUpdate?.Invoke(_foundKeys, _maxKeys);

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            _timeInGame += Time.deltaTime;

            OnTimerUpdate?.Invoke((int)Mathf.Round(_timeInGame));
        }

        public void AddKey()
		{
			_foundKeys++;
            OnKeyValueUpdate?.Invoke(_foundKeys, _maxKeys);
            CheckCollectKey();
        }

        public void LoseGame()
        {
            OnLose?.Invoke();
        }

        public void WinGame()
        {
            OnWin?.Invoke();
        }

        /// <summary>
        /// Checks amount of collected keys with amount of max key
        /// </summary>
        private void CheckCollectKey()
        {
            if(_foundKeys == _maxKeys)
            {
                Destroy(_exit);
            }
        }
	} 
}
