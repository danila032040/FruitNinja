using Scripts.Configurations.Player;
using Scripts.Models;
using Scripts.Views.Player;
using System.Collections;
using UnityEngine;
using Utils;

namespace Scripts.Controllers.Player
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

        public ScoreView ScoreView { get => scoreView; set => scoreView = value; }

        public int GetHealth() => playerModel.Health;
        public int GetScore() => playerModel.CurrScore;
        public int GetMaxScore() => playerModel.MaxScore;
        public int GetCombo() => playerModel.Combo;

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
                if (GetCombo() > comboConfiguration.MinCombo)
                {
                    yield return new WaitForSeconds(comboConfiguration.TimeToDecCombo);
                    SetCombo(GetCombo() - 1);
                }
                yield return null;
            }
        }


        public void AddHealth(int value)
        {
            OnHealthValueChanged?.Invoke(value, playerModel.Health + value);
            playerModel.Health += value;
            healthView.AddHealth(value);
        }
        public void AddScore(int value)
        {
            if (value > 0) value *= GetCombo();
            OnScoreValueChanged?.Invoke(value, playerModel.CurrScore + value);
            playerModel.CurrScore += value;
            ScoreView.AddCurrentScore(value);
        }

        private float _lastTimeSliced;
        public void SetLastTimeFruitSliced(float time)
        {
            float currTime = Time.realtimeSinceStartup;
            if (currTime - _lastTimeSliced <= comboConfiguration.TimeToIncCombo)
                SetCombo(GetCombo() + 1);

            _lastTimeSliced = currTime;
        }

        private void SetHealth(int value)
        {
            playerModel.Health = value;
            healthView.SetHealth(GetHealth());
        }
        private void SetScore(int value)
        {
            playerModel.CurrScore = value;
            ScoreView.SetCurrentScore(GetScore());
        }
        private void SetMaxScore(int value)
        {
            playerModel.MaxScore = value;
            ScoreView.SetMaxScore(GetMaxScore());
        }

        private void SetCombo(int value)
        {
            if (value >= comboConfiguration.MaxCombo) return;
            playerModel.Combo = value;
            ScoreView.SetCombo(GetCombo());
        }
    }
}
