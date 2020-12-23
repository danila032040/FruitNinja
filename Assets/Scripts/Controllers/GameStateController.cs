using Scripts.Configurations.Popup;
using UnityEngine;
using System.Collections;
using System.Linq;
using System;
using Scripts.Models.Blocks.Managers;
using Scripts.Controllers.Player;
using Scripts.Controllers.Spawning;

namespace Scripts.Controllers
{
    public class GameStateController : MonoBehaviour
    {

        public enum GameState
        {
            IsPlaying,
            IsStopped
        }

        [SerializeField] private PlayerController _playerController;
        [SerializeField] private SpawnManager _spawnManager;

        [SerializeField] private PopupSystem _popupSystem;

        [SerializeField] SceneChanger _sceneChanger;

        private GameState gameState;

        public void Start()
        {
            _playerController.OnHealthValueChanged += PlayerController_OnHealthValueChanged;
            RestartGame();
        }

        private void PlayerController_OnHealthValueChanged(int previous, int current)
        {
            if (current <= 0)
            {
                GameOver();
            }
        }

        public void GameOver()
        {
            if (gameState == GameState.IsPlaying)
            {
                gameState = GameState.IsStopped;
                _spawnManager.StopSpawn();
                StartCoroutine(GameOverCoroutine());
            }
        }

        public IEnumerator GameOverCoroutine()
        {
            yield return new WaitUntil(() => !BlockManager.GetInstance().GetAll().Any());
            PlayerPrefs.SetInt("MaxScore", Math.Max(_playerController.GetMaxScore(), _playerController.GetScore()));
            PlayerPrefs.Save();
            _popupSystem.ShowRestartPopup($"Ты набрал {_playerController.GetScore()} очков.", RestartGame, GoToStartScene);
        }

        public async void GoToStartScene()
        {
            await _sceneChanger.LoadStartScene();
        }

        public void RestartGame()
        {
            gameState = GameState.IsPlaying;
            _playerController.ResetPlayer();
            StartCoroutine(StartSpawnCoroutine());
        }

        public IEnumerator StartSpawnCoroutine()
        {
            yield return new WaitForSeconds(3f);
            _spawnManager.StartSpawn();
        }
    }
}

