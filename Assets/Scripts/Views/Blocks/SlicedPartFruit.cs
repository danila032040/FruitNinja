using Scripts.Models.Physics;
using Scripts.Models.Physics.Managers;
using UnityEngine;
namespace Scripts.Views.Blocks
{
    public class SlicedPartFruit : PhysicalObject
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
}
