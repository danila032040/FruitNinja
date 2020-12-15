using System.Collections.Generic;
using UnityEngine;

public class Fruit : Block
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private SlicedPart slicedPartPrefab;

    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public override void Slice(Vector3 direction)
    {
        if (!isSliced)
        {
            List<Sprite> sprites = DivideCurrentSpriteIntoPartsByWidth(2);
            Destroy(gameObject);

            SlicedPart left = Instantiate(slicedPartPrefab, this.gameObject.transform.position, this.gameObject.transform.rotation);
            SlicedPart right = Instantiate(slicedPartPrefab, this.gameObject.transform.position, this.gameObject.transform.rotation);

            left.SetSprite(sprites[0]);
            right.SetSprite(sprites[1]);

            left.AddVelocity(Quaternion.Euler(0, 0, 90) * direction);
            right.AddVelocity(Quaternion.Euler(0, 0, -90) * direction);

        }
        base.Slice(direction);
    }


    private List<Sprite> DivideCurrentSpriteIntoPartsByWidth(int count)
    {
        List<Sprite> sprites = new List<Sprite>();
        Rect startRect = spriteRenderer.sprite.rect;
        float deltaWidth = startRect.width / count;
        Rect currRect = new Rect(0, startRect.y, deltaWidth, startRect.height);
        Vector2 pivot = new Vector2(.5f, .5f);

        while(currRect.x + deltaWidth <= startRect.width)
        {
            sprites.Add(Sprite.Create(spriteRenderer.sprite.texture, currRect, pivot, spriteRenderer.sprite.pixelsPerUnit));
            currRect.x += deltaWidth;
        }

        return sprites;
    }
}
