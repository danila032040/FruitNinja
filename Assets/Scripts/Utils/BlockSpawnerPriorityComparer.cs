using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawnerPriorityComparer : IComparer<BlockSpawner>
{
    public int Compare(BlockSpawner x, BlockSpawner y)
    {
        return x.Priority.CompareTo(y.Priority);
    }
}
