using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth.Scripts.Interfaces
{
    public interface IGameManager
    {
        public event Action OnPlayerDead;
        public event Action OnWin;
        public event Action<int> OnTimerUpdate;
        public event Action<int, int> OnKeyValueUpdate;
        public void AddKey();
        public void KillPlayer();
        public void WinGame();
    }
}
