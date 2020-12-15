using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Views
{
    public class HealthView : MonoBehaviour
    {
        private int _health;

        public void SetHealth(int value)
        {
            _health = value;
        }
    }
}
