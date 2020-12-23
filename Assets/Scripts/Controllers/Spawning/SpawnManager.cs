using Scripts.Configurations.Spawner;
using Scripts.Controllers.Player;
using Scripts.Models.Blocks;
using Scripts.Models.Blocks.Managers;
using Scripts.Models.Blocks.Parent;
using Scripts.Models.Physics.Managers;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Scripts.Controllers.Spawning
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField] private List<ZoneSpawner> zoneSpawners = new List<ZoneSpawner>();
        [SerializeField] private List<Block> blockPrefabs = new List<Block>();

        [SerializeField] private int minBlocksInPack = 2;

        [SerializeField] private int maxBlocksInPack = 5;

        [SerializeField] private float maxDifficulty = 100f;

        [SerializeField] private float minIntervalPack = 2.5f;
        [SerializeField] private float maxIntervalPack = 4f;

        [SerializeField] private float minIntervalBlock = 0.25f;
        [SerializeField] private float maxIntervalBlock = 0.5f;

        [SerializeField] private float spawnBombChance = 1f;
        [SerializeField] private float bombCountPercentageOfPack = 0.1f;

        [SerializeField] private float spawnHeartChance = 1f;


        [SerializeField] private BombBlock bomb;
        [SerializeField] private HeartBlock heart;

        [SerializeField] private PlayerController playerController;

        private Coroutine spawnCoroutine;

        public void StartSpawn()
        {
            spawnCoroutine = StartCoroutine(Spawn());
        }
        public void StopSpawn()
        {
            StopCoroutine(spawnCoroutine);
        }

        private int currentDifficulty;
        private IEnumerator Spawn()
        {
            currentDifficulty = 0;
            while (true)
            {
                StartCoroutine(SpawnPackOfBlocks((int)LerpByDifficulty(minBlocksInPack, maxBlocksInPack)));
                yield return new WaitForSeconds(LerpByDifficulty(maxIntervalPack, minIntervalPack));
                ++currentDifficulty;
            }
        }

        private float LerpByDifficulty(float a, float b) => Mathf.Lerp(a, b, GetPercentage(currentDifficulty, maxDifficulty));

        private float GetPercentage(float min, float max) => Mathf.Min(1, min / max);


        private IEnumerator SpawnPackOfBlocks(int countBlocks)
        {
            int bombsCount = (int)Mathf.Lerp(0, countBlocks, bombCountPercentageOfPack);
            int heartsCount = playerController.HealthConfiguration.MaxHealth - playerController.GetHealth();
            while (countBlocks > 0)
            {
                Block block = ChooseZoneSpawnerByPriority().SpawnBlock(GetRandomBlock());
                BlockManager.GetInstance().Add(block);
                PhysicalObjectManager.GetInstance().Add(block);
                --countBlocks;
                if (bombsCount > 0 && Random.Range(0f, 1f) <= spawnBombChance)
                {
                    BlockManager.GetInstance().Add(ChooseZoneSpawnerByPriority().SpawnBlock(bomb));
                    --bombsCount;
                }
                if (heartsCount > 0 && Random.Range(0f, 1f) <= spawnHeartChance)
                {
                    BlockManager.GetInstance().Add(ChooseZoneSpawnerByPriority().SpawnBlock(heart));
                    --heartsCount;
                }
                yield return new WaitForSeconds(LerpByDifficulty(maxIntervalBlock, minIntervalBlock));
            }
        }

        private ZoneSpawner ChooseZoneSpawnerByPriority()
        {
            int summaryPriority = zoneSpawners.Sum(a => a.Priority);
            int random = Random.Range(0, summaryPriority);

            int currentSum = 0;
            for (int i = 0; i < zoneSpawners.Count; ++i)
            {
                if (currentSum < random && random < currentSum + zoneSpawners[i].Priority)
                {
                    return zoneSpawners[i];
                }
                currentSum += zoneSpawners[i].Priority;
            }
            return zoneSpawners[0];
        }

        private Block GetRandomBlock() => blockPrefabs[Random.Range(0, blockPrefabs.Count - 1)];

    }
}