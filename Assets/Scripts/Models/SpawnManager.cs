using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private BlockSpawner rightSpawner;
    [SerializeField]
    private BlockSpawner downSpawner;
    [SerializeField]
    private BlockSpawner leftSpawner;
    public List<Block> blockPrefabs;

    public void Awake()
    {
        if (rightSpawner == null) rightSpawner = CreateDefaultRightSpawner();
        if (downSpawner == null)  downSpawner = CreateDefaultDownSpawner();
        if (leftSpawner == null)  leftSpawner = CreateDefaultLeftSpawner();
    }

    public BlockSpawner CreateDefaultRightSpawner() =>
        new BlockSpawner()
        {
            Place = BlockSpawner.EPlace.Right,
            Priority = 2,
            MinPlacePercentage = 0.3f,
            MaxPlacePercentage = 0.7f,
            MinVelocity = 2,
            MaxVelocity = 3,
            ViewportPositionGoal = new Vector2(0.5f, 1f)
        };

    public BlockSpawner CreateDefaultDownSpawner() =>
        new BlockSpawner()
        {
            Place = BlockSpawner.EPlace.Down,
            Priority = 5,
            MinPlacePercentage = 0.2f,
            MaxPlacePercentage = 0.8f,
            MinVelocity = 2f,
            MaxVelocity = 3.5f,
            ViewportPositionGoal = new Vector2(0.5f, 0.5f)
        };

    public BlockSpawner CreateDefaultLeftSpawner() =>
        new BlockSpawner()
        {
            Place = BlockSpawner.EPlace.Left,
            Priority = 2,
            MinPlacePercentage = 0.3f,
            MaxPlacePercentage = 0.7f,
            MinVelocity = 2,
            MaxVelocity = 3,
            ViewportPositionGoal = new Vector2(0.5f, 1f)
        };

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
