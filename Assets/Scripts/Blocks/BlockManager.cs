﻿using Scripts.Abstracts;
using System.Collections.Generic;

public class BlockManager : Singleton<BlockManager> , IRepository<Block>
{
    private readonly List<Block> _existBlocks = new List<Block>();
    public IEnumerable<Block> GetAll() => _existBlocks;
    public void Add(Block value) => _existBlocks.Add(value);
    public void Remove(Block value) => _existBlocks.Remove(value);
}
