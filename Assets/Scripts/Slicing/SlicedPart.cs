using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlicedPart : PhysicalObject
{

    [SerializeField] private SpriteRenderer spriteRenderer;

    public SpriteRenderer SpriteRenderer => spriteRenderer;


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetSprite(Sprite sprite)
    {
        this.spriteRenderer.sprite = sprite;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        PhysicalObjectManager.GetInstance().Remove(this);
    }
}
