using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Views
{
    public class HealthView : MonoBehaviour
    {
        [SerializeField] private HeartCollectionView heartCollectionView;

        public void SetHealth(int value)
        {
            heartCollectionView.SetHearts(value);
        }

        public void AddHealth(int value)
        {
            if (value == 0) return;
            heartCollectionView.AddHearts(value);
        }
    }
}
