using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Views
{
    public class ScoreView : MonoBehaviour
    {
        private int _currScore;
        private int _maxScore;
        private bool isHidedMaxScore = false;

        [SerializeField] private float deltaPercentageToAnimateAddingScore;
        [SerializeField] private float deltaPercentageToAnimateMaxAndCurrScore;

        [SerializeField] private Color colorForPositiveScore;
        [SerializeField] private Color colorForNegativeScore;

        [SerializeField] private Text _currScoreText;
        [SerializeField] private Text _maxScoreText;
        [SerializeField] private Text _addingText;

        [SerializeField] private CanvasRenderer _maxAndCurrScore;

        public void SetCurrentScore(int value)
        {
            _currScore = value;
            _currScoreText.text = value.ToString();


            if (_currScore >= _maxScore) TryHideMaxScore();
            else TryShowMaxScore();

        }

        public void SetMaxScore(int value)
        {
            _maxScore = value;
            _maxScoreText.text = value.ToString();

            if (_currScore >= _maxScore) TryHideMaxScore();
            else TryShowMaxScore();
        }


        public void AddCurrentScore(int value)
        {
            StartCoroutine(AddCurrentScoreCoroutine(value));

        }


        private IEnumerator AddCurrentScoreCoroutine(int value)
        {
            Text addText = Instantiate(_addingText, this.transform);

            addText.text = value.ToString("+#;-#;0");
            if (value >= 0) addText.color = colorForPositiveScore;
            else addText.color = colorForNegativeScore;


            float currPercent = 0f;
            while (currPercent < 1)
            {
                addText.transform.position = Vector3.Lerp(addText.transform.position, _currScoreText.transform.position, currPercent);
                yield return null;
                currPercent += deltaPercentageToAnimateAddingScore * Time.unscaledDeltaTime;
            }

            Destroy(addText.gameObject);

            SetCurrentScore(_currScore + value);
            yield break;
        }

        private Coroutine _hideMaxScoreCoroutine;
        private Coroutine _showMaxScoreCoroutine;

        private void TryHideMaxScore()
        {
            if (isHidedMaxScore) return;
            if (_showMaxScoreCoroutine != null) StopCoroutine(_showMaxScoreCoroutine);
            _hideMaxScoreCoroutine = StartCoroutine(HideMaxScoreCoroutine());
            isHidedMaxScore = true;
        }

        private void TryShowMaxScore()
        {
            if (!isHidedMaxScore) return;
            if (_hideMaxScoreCoroutine != null) StopCoroutine(_hideMaxScoreCoroutine);
            _showMaxScoreCoroutine = StartCoroutine(ShowMaxScoreCoroutine());
            isHidedMaxScore = false;
        }


        private Vector3 _oldPosition;

        private IEnumerator HideMaxScoreCoroutine()
        {
            _oldPosition = _currScoreText.transform.position;

            Color startColor = _maxScoreText.color;
            Color endColor = _maxScoreText.color;
            endColor.a = 0;

            float currPercent = 0f;
            while (currPercent <= 1)
            {
                _currScoreText.transform.position = Vector3.Lerp(_currScoreText.transform.position, _maxAndCurrScore.transform.position, currPercent);

                _maxScoreText.color = Color.Lerp(startColor, endColor, currPercent);

                currPercent += deltaPercentageToAnimateMaxAndCurrScore * Time.unscaledDeltaTime;

                yield return null;
            }

            yield break;
        }

        private IEnumerator ShowMaxScoreCoroutine()
        {
            Color startColor = _maxScoreText.color;
            Color endColor = _maxScoreText.color;
            endColor.a = 1;


            float currPercent = 0f;
            while (currPercent <= 1f)
            {
                _currScoreText.transform.position = Vector3.Lerp(_currScoreText.transform.position, _oldPosition, currPercent);

                _maxScoreText.color = Color.Lerp(startColor, endColor, currPercent);

                currPercent += deltaPercentageToAnimateMaxAndCurrScore * Time.unscaledDeltaTime;

                yield return null;
            }

            yield break;
        }
    }
}
