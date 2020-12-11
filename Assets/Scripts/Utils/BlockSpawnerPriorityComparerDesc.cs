using System.Collections.Generic;

public class BlockSpawnerPriorityComparerDesc : IComparer<BlockSpawner>
{
    public int Compare(BlockSpawner x, BlockSpawner y)
    {
        return -x.Priority.CompareTo(y.Priority);
    }
}
