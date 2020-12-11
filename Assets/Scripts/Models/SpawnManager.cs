using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private List<BlockSpawner> blockSpawners;
    [SerializeField]
    private List<Block> blockPrefabs;

    [SerializeField]
    private int minBlocksInPack = 2;

    [SerializeField]
    private int maxBlocksInPack = 5;

    [SerializeField]
    private float maxDifficulty = 100f;

    [SerializeField]
    private float minIntervalPack = 2.5f;
    [SerializeField]
    private float maxIntervalPack = 4f;

    [SerializeField]
    private float minIntervalBlock = 0.25f;
    [SerializeField]
    private float maxIntervalBlock = 0.5f;

    public void Start()
    {
        blockSpawners.Sort(new BlockSpawnerPriorityComparerDesc());
        StartCoroutine(Spawn());
    }

    private int currentDifficulty;
    public IEnumerator Spawn()
    {
        currentDifficulty = 0;
        while (true)
        {
            StartCoroutine(SpawnPackOfBlocks(GetCurrentCountBlocksInPack()));
            yield return new WaitForSeconds(GetCurrentInvervalPack());
            ++currentDifficulty;
        }
    }
    public float GetCurrentInvervalPack()
    {
        return Mathf.Lerp(maxIntervalPack, minIntervalPack, GetPercentage(currentDifficulty, maxDifficulty));
    }

    public float GetCurrentInvervalBlock()
    {
        return Mathf.Lerp(maxIntervalBlock, minIntervalBlock, GetPercentage(currentDifficulty, maxDifficulty));
    }

    public int GetCurrentCountBlocksInPack()
    {
        return (int)Mathf.Lerp(minBlocksInPack, maxBlocksInPack, GetPercentage(currentDifficulty, maxDifficulty));
    }

    private float GetPercentage(float min, float max) => Mathf.Min(1, min / max);

    public IEnumerator SpawnPackOfBlocks(int countBlocks)
    {
        while (countBlocks > 0)
        {
            int random = Random.Range(BlockSpawner.MinPriorityValue, BlockSpawner.MaxPriorityValue);

            foreach (BlockSpawner item in blockSpawners)
            {
                if (random <= item.Priority)
                {
                    item.SpawnOneBlock(GetRandomBlock());
                    --countBlocks;
                    yield return new WaitForSeconds(GetCurrentInvervalBlock());
                    if (countBlocks == 0) break;
                }
            }
        }
    }
    public Block GetRandomBlock() => blockPrefabs[Random.Range(0, blockPrefabs.Count - 1)];

}
