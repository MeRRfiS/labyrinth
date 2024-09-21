using Labyrinth.Scripts;
using Labyrinth.Scripts.Interfaces;
using UnityEngine;
using Zenject;

namespace Labyrinth.Scripts.Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private AudioManager _audioManager;

        public override void InstallBindings()
        {
            BindGameManager();
            BindAudioManager();
        }

        private void BindAudioManager()
        {
            Container.Bind<IAudioManager>()
                     .FromInstance(_audioManager)
                     .AsSingle();
        }

        private void BindGameManager()
        {
            Container.Bind<IGameManager>()
                             .FromInstance(_gameManager)
                             .AsSingle();
        }
    } 
}