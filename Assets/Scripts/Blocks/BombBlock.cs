﻿using Scripts.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            foreach (Block item in BlockManager.existBlocks)
            {
                item.DisableSlice();

                Vector3 distance = item.transform.position - this.transform.position;
                item.AddVelocity(distance * _velocityPerDistance);
            }

            BombExplosionEffect effect = Instantiate(bombExplosionEffect, this.transform);

            Destroy(this.gameObject);
        }
    }
}
