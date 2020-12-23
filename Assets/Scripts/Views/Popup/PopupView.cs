using DG.Tweening;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Views.Popup
{
    public class PopupView : MonoBehaviour
    {
        [SerializeField] protected float _blockInputOpacity;
        [SerializeField] protected List<string> _buttonTextValues;

        [SerializeField] protected Text _messageText;
        [SerializeField] protected List<Button> _buttons;

        [SerializeField] protected Image _blockingInputImage;

        [SerializeField] protected CanvasGroup _canvasGroup;
        [SerializeField] protected Canvas _canvas;

        private void Start()
        {
            int n = _buttons.Count;

            for (int i = 0; i < n; ++i)
            {
                _buttons[i].GetComponentInChildren<Text>().text = _buttonTextValues[i];
            }

        }

        public virtual void Show(string message, Action closed, params Action[] actions)
        {
            _messageText.text = message;
            for (int i = 0; i < actions.Length; ++i)
            {
                int curI = i;
                this._buttons[curI].onClick.AddListener(() => actions[curI]());
            }
            foreach (Button button in _buttons)
            {
                button.onClick.AddListener(() =>
                {
                    Destroy(this.gameObject, this.HideWithAnim());
                    closed();
                });
            }
            ShowWithAnim();
        }

        protected float ShowWithAnim()
        {
            this.transform.DOScale(1, 1);
            this._canvasGroup.DOFade(1, 1);
            this._blockingInputImage.DOFade(_blockInputOpacity, 1);
            return 1;
        }
        protected float HideWithAnim()
        {
            this.transform.DOScale(0, 1);
            this._canvasGroup.DOFade(0, 1);
            this._blockingInputImage.DOFade(0, 1);
            return 1;
        }

        public int SortOrder
        {
            get => _canvas.sortingOrder;
            set
            {
                _canvas.sortingOrder = value;
            }
        }
    }
}
