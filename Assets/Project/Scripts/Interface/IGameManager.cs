using System;

namespace Labyrinth.Scripts.Interfaces
{
    /// <summary>
    /// Interface for managing game events and player state
    /// </summary>
    public interface IGameManager
    {
        /// <summary>
        /// Event triggerd when player loses the game
        /// </summary>
        public event Action OnLose;

        /// <summary>
        /// Event triggerd when player wins the game
        /// </summary>
        public event Action OnWin;

        /// <summary>
        /// Event triggerd to update the timer
        /// </summary>
        public event Action<int> OnTimerUpdate;

        /// <summary>
        /// Event triggerd to update count collected key
        /// </summary>
        public event Action<int, int> OnKeyValueUpdate;

        /// <summary>
        /// Add a key to counter
        /// </summary>
        public void AddKey();

        /// <summary>
        /// Handles player lose
        /// </summary>
        public void LoseGame();

        /// <summary>
        /// Handles player win
        /// </summary>
        public void WinGame();
    }
}
