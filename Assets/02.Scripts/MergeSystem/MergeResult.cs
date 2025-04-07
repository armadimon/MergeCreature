using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeResult
{
    public bool IsSuccess { get; }
    public string ErrorMessage { get; }

    public MergeItem NewItem { get; }
    public Vector2Int Position { get; }
    public List<MergeItem> ConsumedItems { get; }

    public MergeResult(bool isSuccess, MergeItem newItem, Vector2Int position, List<MergeItem> consumedItems, string errorMessage = "")
    {
        IsSuccess = isSuccess;
        NewItem = newItem;
        Position = position;
        ConsumedItems = consumedItems;
        ErrorMessage = errorMessage;
    }
}
