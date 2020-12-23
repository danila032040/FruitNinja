using Scripts.Controllers;
using UnityEngine;

public class HeartBlock : Block
{
    [SerializeField] private PlayerController playerController;
    //[SerializeField] private BombExplosionEffect bombExplosionEffect;

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
