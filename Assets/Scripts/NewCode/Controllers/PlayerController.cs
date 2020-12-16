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
            SetScore(scoreConfiguration.StartScore);
            SetMaxScore(20);
        }


        public void AddHealth(int value)
        {
            playerModel.health += value;
            healthView.AddHealth(value);
        }
        public void AddScore(int value)
        {
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
