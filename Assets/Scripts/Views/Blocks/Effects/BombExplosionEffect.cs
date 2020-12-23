using System.Collections;
using UnityEngine;

namespace Scripts.Views.Blocks.Effects
{
    public class BombExplosionEffect : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private ParticleSystem particSystem;

        [SerializeField] private float explosionImageTimeDisappearing;
        [SerializeField] private float changeOpacityDelta;



        public void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            particSystem = GetComponent<ParticleSystem>();
        }
        public void ShowEffects()
        {
            StartCoroutine(ShowEffectCoroutine());
        }

        private IEnumerator ShowEffectCoroutine()
        {
            yield return ShowParticlesCoroutine();
            yield return ShowExplosionImageCoroutine();
            Destroy(gameObject);
        }

        private IEnumerator ShowParticlesCoroutine()
        {
            particSystem.Play();
            yield break;
        }
        public IEnumerator ShowExplosionImageCoroutine()
        {
            spriteRenderer.enabled = true;

            float currOpacity = spriteRenderer.color.a;

            while (spriteRenderer.color.a > 0)
            {
                yield return new WaitForSeconds(explosionImageTimeDisappearing / changeOpacityDelta);
                currOpacity = currOpacity - changeOpacityDelta;

                Color newColor = spriteRenderer.color;
                newColor.a = currOpacity;
                spriteRenderer.color = newColor;
            }

            spriteRenderer.enabled = false;
        }

    }
}