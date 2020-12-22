using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Views
{
    public class AnimatedButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        private Button _button;

        [SerializeField] private float _downScale = 0.8f;
        [SerializeField] private float _upScale = 1f;

        private void Start()
        {
            _button = GetComponent<Button>();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _button.transform.DOScale(_downScale, .25f);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _button.transform.DOScale(_upScale, .25f);
        }
    }
}
