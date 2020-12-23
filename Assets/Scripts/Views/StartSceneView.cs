using DG.Tweening;
using Scripts.Controllers;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Views
{
    public class StartSceneView : MonoBehaviour
    {
        [SerializeField] private Text _gameNameText;
        [SerializeField] private Text _maxScoreText;
        [SerializeField] private Button _buttonStart;

        [SerializeField] private SceneChanger _sceneChanger;

        [SerializeField] private float _gameNameTextMoveTo;
        [SerializeField] private float _maxScoreTextMoveTo;


        public void Start()
        {
            _maxScoreText.text = $"Макс. счет: {PlayerPrefs.GetInt("MaxScore", 0)}";
            _buttonStart.onClick.AddListener(async () =>
            {
                await _sceneChanger.LoadGameScene();
            });

            AnimateGameName();
            StartCoroutine(AnimateMaxScoreText());
        }

        public void AnimateGameName()
        {
            _gameNameText.rectTransform.DOAnchorPosY(_gameNameTextMoveTo, 1f);
        }
        public IEnumerator AnimateMaxScoreText()
        {
            _maxScoreText.transform.DORotate(Vector3.zero, 1.5f);
            _maxScoreText.rectTransform.DOAnchorPosX(_maxScoreTextMoveTo, 1.5f);
            yield break;
        }
    }
}
