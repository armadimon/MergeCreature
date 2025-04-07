using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeBoardView : UIBase
{
    public Transform BoardContainer;
    public MergeCellView CellPrefab;
    [SerializeField]
    private GameObject _mergeCellPrefab;

    private MergeBoard _board;
    private MergeSystem _mergeSystem;
    private MergePresenter _presenter;
    private Dictionary<Vector2Int, MergeItem> boardItems = new Dictionary<Vector2Int, MergeItem>();

    public override void Opened(params object[] args)
    {
        if (args[0] is MergeBoard board && args[1] is MergeSystem system)
        {
            Initialize(board, system);
        }
    }
    
    public override void HideDirect()
    {
    }
    
    public void Initialize(MergeBoard board, MergeSystem mergeSystem)
    {
        _board = board;
        _mergeSystem = mergeSystem;
        _presenter = new MergePresenter(this, _mergeSystem);

        for (int x = 0; x < board.Rows; x++)
        {
            for (int y = 0; y < board.Columns; y++)
            {
                var cellView = Instantiate(CellPrefab, BoardContainer);
                cellView.Initialize(board.GetCell(x, y));
            }
        }
    }
    
    public void UpdateBoard(MergeResult result)
    {
        if (!result.IsSuccess)
        {
            Debug.LogWarning("Merge failed: " + result.ErrorMessage);
            return;
        }
        
        foreach (var item in result.ConsumedItems)
        {
            RemoveItemFromBoard(item);
        }
        
        AddItemToBoard(result.NewItem, result.Position);
        
        RefreshBoardView();
    }
    
    private void RemoveItemFromBoard(MergeItem item)
    {
        if (boardItems.ContainsKey(item.Position))
        {
            boardItems.Remove(item.Position);
            Destroy(item.gameObject); // 이제 문제 없음
        }
    }
    
    private void AddItemToBoard(MergeItem newItem, Vector2Int position)
    {
        GameObject newItemGO = Instantiate(_mergeCellPrefab, BoardContainer);
        newItemGO.transform.position = GetWorldPosition(position);
    
        MergeItem mergeItemComponent = newItemGO.GetComponent<MergeItem>();
        mergeItemComponent.Initialize(position);
        boardItems[position] = mergeItemComponent;
    }
    
    private Vector3 GetWorldPosition(Vector2Int position)
    {
        float cellSize = 1.0f;
        Vector3 boardOrigin = BoardContainer.position;

        return boardOrigin + new Vector3(position.x * cellSize, position.y * cellSize, 0);
    }
    
    private void RefreshBoardView()
    {
        foreach (var item in boardItems.Values)
        {
        }
    }
}

