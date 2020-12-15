using Scripts.Configurations;
using Scripts.Models;
using Scripts.Views;
using UnityEngine;

namespace Scripts.Controllers
{
    public class PlayerController : MonoBehaviour
    {

        [SerializeField] private PlayerModel playerModel;
        [SerializeField] private HealthView healthView;
        [SerializeField] private ScoreView scoreView;

        [SerializeField] private HealthConfiguration healthConfiguration;
        [SerializeField] private ScoreConfiguration scoreConfiguration;

        public HealthConfiguration HealthConfiguration => healthConfiguration;
        public ScoreConfiguration ScoreConfiguration => scoreConfiguration;

        private void Start()
        {
            ResetPlayer();
        }

        public void ResetPlayer()
        {
            SetHealth(healthConfiguration.MaxHealth);
            SetScore(scoreConfiguration.MinScore);
        }


        public void AddHealth(int value) => SetHealth(playerModel.health + value);
        public void AddScore(int value) => SetScore(playerModel.score + value);


        private void SetHealth(int value)
        {
            playerModel.health = value;
            healthView.SetHealth(playerModel.health);
        }
        private void SetScore(int value)
        {
            playerModel.score = value;
            scoreView.SetScore(playerModel.score);
        }
    }
}
