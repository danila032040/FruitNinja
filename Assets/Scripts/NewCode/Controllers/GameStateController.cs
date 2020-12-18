using Scripts.Controllers;
using Scripts.Views;
using UnityEngine;

public class GameStateController : MonoBehaviour
{

    public enum GameState
    {
        IsPlaying,
        IsStopped
    }

    [SerializeField] private PlayerController _playerController;
    [SerializeField] private SpawnManager _spawnManager;
    [SerializeField] private GameOverView _gameOverView;

    private GameState gameState;

    public void Start()
    {
        _playerController.OnHealthValueChanged += PlayerController_OnHealthValueChanged;
        _gameOverView.OnRestart += () => RestartGame();
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
        _spawnManager.StopSpawn();
        _gameOverView.SetMaxScore(_playerController.GetMaxScore());
        _gameOverView.Show();
    }

    public void RestartGame()
    {
        _playerController.ResetPlayer();
        _spawnManager.StartSpawn();
    }
}

