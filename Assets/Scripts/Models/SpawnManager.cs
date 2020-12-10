using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public BlockSpawner rightSpawner;
    public BlockSpawner downSpawner;
    public BlockSpawner leftSpawner;
    public List<Block> blockPrefabs;

    public void Start()
    {
        StartCoroutine(SpawnBlock());
    }

    public IEnumerator SpawnBlock()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            int random = Random.Range(BlockSpawner.MinPriorityValue, BlockSpawner.MaxPriorityValue);

            if (random <= rightSpawner.Priority) rightSpawner.SpawnOneBlock(GetRandomBlock());
            if (random <= leftSpawner.Priority) leftSpawner.SpawnOneBlock(GetRandomBlock());
            if (random <= downSpawner.Priority) downSpawner.SpawnOneBlock(GetRandomBlock());
        }
    }

    public Block GetRandomBlock() => blockPrefabs[Random.Range(0, blockPrefabs.Count - 1)];

}
