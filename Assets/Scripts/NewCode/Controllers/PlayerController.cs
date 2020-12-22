using Scripts.Configurations;
using Scripts.Models;
using Scripts.Views;
using UnityEngine;
using Utils;

namespace Scripts.Controllers
{
    public class PlayerController : MonoBehaviour
    {

        [SerializeField] private PlayerModel playerModel;
        [SerializeField] private HealthView healthView;
        [SerializeField] private ScoreView scoreView;

        [SerializeField] private HealthConfiguration healthConfiguration;
        [SerializeField] private ScoreConfiguration scoreConfiguration;


        public event ValueChanged OnHealthValueChanged;
        public event ValueChanged OnScoreValueChanged;

        public HealthConfiguration HealthConfiguration => healthConfiguration;
        public ScoreConfiguration ScoreConfiguration => scoreConfiguration;

        public int GetHealth() => playerModel.health;
        public int GetScore() => playerModel.currScore;
        public int GetMaxScore() => playerModel.maxScore;

        private void Start()
        {
            ResetPlayer();
        }

        public void ResetPlayer()
        {
            SetHealth(healthConfiguration.MaxHealth);
            SetScore(scoreConfiguration.StartScore);
            SetMaxScore(PlayerPrefs.GetInt("MaxScore",0));
        }


        public void AddHealth(int value)
        {
            OnHealthValueChanged?.Invoke(value, playerModel.health + value);
            playerModel.health += value;
            healthView.AddHealth(value);
        }
        public void AddScore(int value)
        {
            OnScoreValueChanged?.Invoke(value, playerModel.currScore + value);
            playerModel.currScore += value;
            scoreView.AddCurrentScore(value);
        }

        private void SetHealth(int value)
        {
            playerModel.health = value;
            healthView.SetHealth(playerModel.health);
        }
        private void SetScore(int value)
        {
            playerModel.currScore = value;
            scoreView.SetCurrentScore(playerModel.currScore);
        }
        private void SetMaxScore(int value)
        {
            playerModel.maxScore = value;
            scoreView.SetMaxScore(playerModel.maxScore);
        }
    }
}
