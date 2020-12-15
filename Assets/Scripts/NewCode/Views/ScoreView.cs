using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Scripts.Views
{
    public class ScoreView : MonoBehaviour
    {
        private int _score;

        public void SetScore(int value)
        {
            _score = value;
        }
    }
}
