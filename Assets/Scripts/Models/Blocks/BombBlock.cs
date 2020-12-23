using Scripts.Controllers;
using Scripts.Controllers.Player;
using Scripts.Models.Blocks.Managers;
using Scripts.Models.Blocks.Parent;
using Scripts.Models.Physics;
using Scripts.Models.Physics.Managers;
using Scripts.Views.Blocks.Effects;
using UnityEngine;

namespace Scripts.Models.Blocks
{
    public class BombBlock : Block
    {
        [SerializeField] private float _explosionRadius;

        [SerializeField] private float _velocityPerDistance;

        [SerializeField] private PlayerController playerController;
        [SerializeField] private BombExplosionEffect bombExplosionEffect;

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
                playerController.AddHealth(playerController.HealthConfiguration.AddHealthForSlicingBomb);

                foreach (Block item in BlockManager.GetInstance().GetAll()) item.DisableSlice();

                foreach (PhysicalObject item in PhysicalObjectManager.GetInstance().GetAll())
                {
                    Vector3 distance = item.transform.position - this.transform.position;
                    item.AddVelocity(distance * _velocityPerDistance);
                }


                Explode();
                isSliced = true;
            }
        }

        private void Explode()
        {
            Vector3 effectPosition = this.transform.position;
            effectPosition.z = 0;
            BombExplosionEffect effect = Instantiate(bombExplosionEffect, effectPosition, this.transform.rotation);
            effect.ShowEffects();

            Destroy(this.gameObject);
        }
    }
}
