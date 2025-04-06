using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class MergeSystem
{
    public IObservable<MergeResult> OnMergeSuccess => _onMergeSuccess;
    private Subject<MergeResult> _onMergeSuccess = new Subject<MergeResult>();

    public bool TryMerge(MergeCell cellA, MergeCell cellB)
    {
        if (cellA.IsEmpty || cellB.IsEmpty) return false;
        if (cellA.Item.ItemID != cellB.Item.ItemID) return false;
        if (cellA.Item.Level != cellB.Item.Level) return false;

        cellA.Item.LevelUp();
        cellB.ClearItem();

        _onMergeSuccess.OnNext(new MergeResult(
            isSuccess: true,   
            newItem: cellA.Item,
            position: cellA.Position,
            consumedItems: new List<MergeItem> { cellB.Item },
            errorMessage: ""
        ));
        return true;
    }
}