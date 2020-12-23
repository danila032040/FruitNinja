using Scripts.Configurations;
using Scripts.Models;
using Scripts.Views;
using System.Collections;
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
        [SerializeField] private ComboConfiguration comboConfiguration;


        public event ValueChanged OnHealthValueChanged;
        public event ValueChanged OnScoreValueChanged;

        public HealthConfiguration HealthConfiguration => healthConfiguration;
        public ScoreConfiguration ScoreConfiguration => scoreConfiguration;
        public ComboConfiguration ComboConfiguration => comboConfiguration;

        public int GetHealth() => playerModel.health;
        public int GetScore() => playerModel.currScore;
        public int GetMaxScore() => playerModel.maxScore;
        public int GetCombo() => playerModel.combo;

        private void Start()
        {
            ResetPlayer();
            StartCoroutine(DecCombo());
        }

        public void ResetPlayer()
        {
            SetHealth(healthConfiguration.MaxHealth);
            SetScore(scoreConfiguration.StartScore);
            SetMaxScore(PlayerPrefs.GetInt("MaxScore", 0));
            SetCombo(comboConfiguration.MinCombo);
        }

        private IEnumerator DecCombo()
        {
            while (true)
            {
                if (playerModel.combo > comboConfiguration.MinCombo)
                {
                    yield return new WaitForSeconds(comboConfiguration.TimeToDecCombo);
                    SetCombo(playerModel.combo - 1);
                }
                yield return null;
            }
        }


        public void AddHealth(int value)
        {
            OnHealthValueChanged?.Invoke(value, playerModel.health + value);
            playerModel.health += value;
            healthView.AddHealth(value);
        }
        public void AddScore(int value)
        {
            if (value > 0) value *= playerModel.combo;
            OnScoreValueChanged?.Invoke(value, playerModel.currScore + value);
            playerModel.currScore += value;
            scoreView.AddCurrentScore(value);
        }

        private float _lastTimeSliced;
        public void SetLastTimeFruitSliced(float time)
        {
            float currTime = Time.realtimeSinceStartup;
            if (currTime - _lastTimeSliced <= comboConfiguration.TimeToIncCombo)
                SetCombo(playerModel.combo + 1);

            _lastTimeSliced = currTime;
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

        private void SetCombo(int value)
        {
            if (value >= comboConfiguration.MaxCombo) return;
            playerModel.combo = value;
            scoreView.SetCombo(playerModel.combo);
        }
    }
}
