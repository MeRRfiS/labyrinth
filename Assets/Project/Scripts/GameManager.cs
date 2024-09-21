using Labyrinth.Scripts.Interfaces;
using Labyrinth.Scripts.Items;
using System;
using UnityEngine;

namespace Labyrinth.Scripts
{
	public class GameManager : MonoBehaviour, IGameManager
    {
        [SerializeField] private GameObject _exit;
		private int _maxKeys;
		private int _foundKeys = 0;
        private float _timeInGame = 0;

        public event Action OnPlayerDead;
        public event Action OnWin;
        public event Action<int> OnTimerUpdate;
        public event Action<int, int> OnKeyValueUpdate;

        private void Start()
        {
            _maxKeys = FindObjectsByType<Key>(FindObjectsSortMode.None).Length;
            OnKeyValueUpdate?.Invoke(_foundKeys, _maxKeys);
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

        public void KillPlayer()
        {
            OnPlayerDead?.Invoke();
        }

        public void WinGame()
        {
            OnWin?.Invoke();
        }

        private void CheckCollectKey()
        {
            if(_foundKeys == _maxKeys)
            {
                Destroy(_exit);
            }
        }
	} 
}
