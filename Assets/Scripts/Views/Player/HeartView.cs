using UnityEngine;

namespace Scripts.Views.Player
{
    public class HeartView : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        public Animator Animator => _animator;
    }
}