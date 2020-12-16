using Assets.Scripts.NewCode.Resources;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Views
{
    public class HeartView : MonoBehaviour
    {
        [SerializeField] public Animator Animator;

        private void Start()
        {
            Animator = GetComponent<Animator>();
        }
    }
}