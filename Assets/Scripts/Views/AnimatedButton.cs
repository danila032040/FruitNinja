using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;

namespace Scripts.Views
{
    [RequireComponent(typeof(Button))]
    public class AnimatedButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private Button _button;

        [SerializeField] private float _downScale = 0.8f;
        [SerializeField] private float _upScale = 1f;

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
