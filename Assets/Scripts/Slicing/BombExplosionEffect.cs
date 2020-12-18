using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

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
        yield break;
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
        yield break;
    }

}
