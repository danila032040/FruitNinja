using Scripts.Configurations;
using Scripts.Controllers;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : Block
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private SlicedPart slicedPartPrefab;
    [SerializeField] private SlicingFruitEffect slicingEffectPrefab;

    [SerializeField] private Color FruitColor;

    private PlayerController playerController;

    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerController = FindObjectOfType<PlayerController>();
    }

    public override void Slice(Vector3 direction)
    {
        SliceProcess(direction);
        base.Slice(direction);
    }

    public void SliceProcess(Vector3 direction)
    {
        if (!isSliced)
        {
            this.isSliced = true;
            
            List<Sprite> sprites = DivideCurrentSpriteIntoPartsByWidth(2);
            Destroy(gameObject);

            //TOFIX: Make method
            SlicedPart left = Instantiate(slicedPartPrefab, this.gameObject.transform.position, this.gameObject.transform.rotation);
            SlicedPart right = Instantiate(slicedPartPrefab, this.gameObject.transform.position, this.gameObject.transform.rotation);

            PhysicalObjectManager.GetInstance().Add(left);
            PhysicalObjectManager.GetInstance().Add(right);

            left.SetSprite(sprites[0]);
            right.SetSprite(sprites[1]);

            left.AddVelocity(Quaternion.Euler(0, 0, 90) * direction);
            right.AddVelocity(Quaternion.Euler(0, 0, -90) * direction);

            SlicingFruitEffect effect = Instantiate(slicingEffectPrefab, this.gameObject.transform.position, this.gameObject.transform.rotation);

            effect.SetColor(FruitColor);
            effect.ShowEffects();

            playerController.AddScore(playerController.ScoreConfiguration.AddScoreForFruit);
            playerController.SetLastTimeFruitSliced(Time.realtimeSinceStartup);
        }
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

    protected override void OnDestroy()
    {
        base.OnDestroy();
        if (!isSliced)
        {
            playerController.AddHealth(playerController.HealthConfiguration.AddHealthForSlicingFruit);
            playerController.AddScore(playerController.ScoreConfiguration.RemoveScoreForFruit);
        }
    }
}
