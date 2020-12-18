using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Scripts.Views
{
    public class GameOverView : MonoBehaviour
    {
        [SerializeField] private Text _gameOverText;
        [SerializeField] private Button _restartButton;

        private float _maxScore;

        public event UnityAction OnRestart;

        public void Start()
        {
            StartCoroutine(HideView());
            _restartButton.onClick.AddListener(() => RestartButtonClicked());
        }

        public void SetMaxScore(float value) => _maxScore = value;

        public void Show()
        {
            _gameOverText.text = $"Max score: {_maxScore}";
            StartCoroutine(ShowView());
        }

        public void RestartButtonClicked()
        {
            StartCoroutine(HideView());
            OnRestart?.Invoke();
        }

        private IEnumerator ShowView()
        {
            this._gameOverText.gameObject.SetActive(true);
            this._restartButton.gameObject.SetActive(true);
            yield break;
        }

        private IEnumerator HideView()
        {
            this._gameOverText.gameObject.SetActive(false);
            this._restartButton.gameObject.SetActive(false);
            yield break;
        }
    }
}
