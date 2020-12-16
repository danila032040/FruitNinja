using Assets.Scripts.NewCode.Resources;
using System.Collections;
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
            while (hearts.Count > value) TryRemoveHeartWithAnim();
            while (hearts.Count < value) TryAddHeartWithAnim();
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


        private void TryAddHeartWithAnim()
        {
            StartCoroutine(AddHeartWithAnimCoroutine());
        }

        private void TryRemoveHeartWithAnim()
        {
            StartCoroutine(RemoveHeartWithAnimCoroutine());
        }

        private IEnumerator AddHeartWithAnimCoroutine()
        {
            HeartView heart = Instantiate(_heartViewPrefab, transform);
            hearts.Add(heart);
            heart.Animator.SetTrigger(AnimatorResources.CreateHeartTriggerId);
            yield break;
        }

        private IEnumerator RemoveHeartWithAnimCoroutine()
        {
            if (hearts.Count > 0)
            {
                HeartView heart = hearts[0];
                hearts.RemoveAt(0);

                heart.Animator.SetTrigger(AnimatorResources.DeleteHeartTriggerId);

                float animLength = heart.Animator.runtimeAnimatorController.animationClips[0].length;

                yield return new WaitForSeconds(animLength);
                Destroy(heart.gameObject);
            }
        }

    }
}