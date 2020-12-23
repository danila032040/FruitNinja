using Scripts.Controllers;
using Scripts.Controllers.Player;
using Scripts.Models.Blocks.Parent;
using UnityEngine;

namespace Scripts.Models.Blocks
{
    public class HeartBlock : Block
    {
        [SerializeField] private PlayerController playerController;

        public void Start()
        {
            playerController = FindObjectOfType<PlayerController>();
        }

        public override void Slice(Vector3 direction)
        {
            SliceProcess();
            base.Slice(direction);
        }

        private void SliceProcess()
        {
            if (!isSliced)
            {
                playerController.AddHealth(playerController.HealthConfiguration.AddHealthForSlicingHeart);

                Destroy(this.gameObject);

                isSliced = true;
            }
        }
    }
}
