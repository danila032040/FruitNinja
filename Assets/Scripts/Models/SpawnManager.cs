using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
            ChooseBlockSpawnerByPriority().SpawnOneBlock(GetRandomBlock());
            --countBlocks;
            yield return new WaitForSeconds(GetCurrentInvervalBlock());
        }
    }

    public BlockSpawner ChooseBlockSpawnerByPriority()
    {
        int summaryPriority = blockSpawners.Sum(a => a.Priority);
        int random = Random.Range(0, summaryPriority);

        int currentSum = 0;
        for (int i=0; i<blockSpawners.Count; ++i)
        {
            if (currentSum < random && random < currentSum+blockSpawners[i].Priority)
            {
                return blockSpawners[i];
            }
            currentSum += blockSpawners[i].Priority;
        }
        return blockSpawners[0];
    }

    public Block GetRandomBlock() => blockPrefabs[Random.Range(0, blockPrefabs.Count - 1)];

}
