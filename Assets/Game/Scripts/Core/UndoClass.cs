using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndoClass
{
    public int blockCount; 

    public List<WoodBlock> fromWoodBlocks;
    public List<WoodBlock> toWoodBlocks;

    public WoodStore fromWS;
    public WoodStore toWS;

    public UndoClass (WoodStore from, WoodStore to, int blockCount)
    {
        fromWS = from;
        toWS = to;

        fromWoodBlocks = new List<WoodBlock>(from.ListWoodBlock);
        toWoodBlocks = new List<WoodBlock>(to.ListWoodBlock);

        this.blockCount = blockCount;
    }
}
