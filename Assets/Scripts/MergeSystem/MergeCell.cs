using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeCell
{
    public int X { get; }
    public int Y { get; }
    public MergeItem Item { get; private set; }
    public Vector2Int Position => new Vector2Int(X, Y);
    public MergeCell(int x, int y)
    {
        X = x;
        Y = y;
        Item = null;
    }

    public bool IsEmpty => Item == null;

    public void SetItem(MergeItem item) => Item = item;
    public void ClearItem() => Item = null;
}