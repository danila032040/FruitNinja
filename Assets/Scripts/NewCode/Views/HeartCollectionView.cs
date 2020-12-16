using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Views
{
    public class HeartCollectionView : MonoBehaviour
    {
        [SerializeField] private HeartView _heartViewPrefab;

        private List<HeartView> hearts = new List<HeartView>();

        public void SetHearts(int value)
        {
            while (hearts.Count > value) TryRemoveHeart();
            while (hearts.Count < value) TryAddHeart();
        }

        public void AddHearts(int value)
        {
            while (value < 0)
            {
                TryRemoveHeartWithAnim();
                ++value;
            }
            while (value > 0)
            {
                TryAddHeartWithAnim();
                --value;
            }
        }

        private void TryAddHeart()
        {
            hearts.Add(Instantiate(_heartViewPrefab, transform));
        }

        private void TryRemoveHeart()
        {
            if (hearts.Count > 0)
            {
                Destroy(hearts[0].gameObject);
                hearts.RemoveAt(0);
            }
        }

        private void TryAddHeartWithAnim()
        {
            hearts.Add(Instantiate(_heartViewPrefab, transform));
        }

        private void TryRemoveHeartWithAnim()
        {
            if (hearts.Count > 0)
            {
                Destroy(hearts[0].gameObject);
                hearts.RemoveAt(0);
            }
        }
    }
}