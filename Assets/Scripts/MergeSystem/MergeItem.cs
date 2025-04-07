using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeItem : MonoBehaviour
{
    public string ItemID { get; }
    public int Level { get; private set; }
    public Vector2Int Position { get; private set; }

    public void Initialize(Vector2Int position)
    {
        Position = position;
    }
    
    public MergeItem(string itemId, int level)
    {
        ItemID = itemId;
        Level = level;
    }

    public void LevelUp() => Level++;
}