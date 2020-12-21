using Scripts.Controllers;
using Scripts.Configurations.Popup;
using Scripts.Views;
using UnityEngine;
using System.Collections;
using System.Linq;

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
            StartCoroutine(DisplayRestartCoroutine());
        }
    }

    public IEnumerator DisplayRestartCoroutine()
    {
        yield return new WaitUntil(() => !BlockManager.GetInstance().GetAll().Any());
        _popupSystem.ShowRestartPopup($"Ты набрал {_playerController.GetScore()} очков.", RestartGame);
    }

    public void RestartGame()
    {
        gameState = GameState.IsPlaying;
        _playerController.ResetPlayer();
        _spawnManager.StartSpawn();
    }
}

