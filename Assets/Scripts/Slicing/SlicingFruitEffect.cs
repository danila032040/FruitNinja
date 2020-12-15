using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlicingFruitEffect : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private ParticleSystem particSystem;

    [SerializeField] private float juiceTimeDisappearing;
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
        yield return ShowJuiceCoroutine();
        Destroy(gameObject);
        yield break;
    }

    private IEnumerator ShowParticlesCoroutine()
    {
        particSystem.Play();
        yield break;
    }
    public IEnumerator ShowJuiceCoroutine()
    {
        spriteRenderer.enabled = true;

        float currOpacity = spriteRenderer.color.a;

        while(spriteRenderer.color.a>0)
        {
            yield return new WaitForSeconds(juiceTimeDisappearing / changeOpacityDelta);
            currOpacity = currOpacity - changeOpacityDelta;

            Color newColor = spriteRenderer.color;
            newColor.a = currOpacity;
            spriteRenderer.color = newColor;
        }

        spriteRenderer.enabled = false;
        yield break;
    }

    public void SetColor(Color fruitColor)
    {
        spriteRenderer.color = fruitColor;
        var ps = particSystem.main;
        ps.startColor = fruitColor;

    }
}
