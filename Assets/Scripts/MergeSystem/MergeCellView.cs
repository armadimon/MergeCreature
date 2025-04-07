using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MergeCellView : MonoBehaviour, IDropHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image ItemImage;
    private MergeCell _cell;

    // public override void Opened(params object[] args)
    // {
    //     
    // }
    //
    // public override void HideDirect()
    // {
    // }

    public void Initialize(MergeCell cell)
    {
        _cell = cell;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (_cell.IsEmpty)
        {
            ItemImage.enabled = false;
        }
        else
        {
            ItemImage.enabled = true;
            // 아이템의 스프라이트 변경
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (_cell.IsEmpty) return;
        // 드래그 시작 처리
    }

    public void OnDrag(PointerEventData eventData)
    {
        // 드래그 중 처리
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // 드래그 끝 처리
    }

    public void OnDrop(PointerEventData eventData)
    {
        // 머지 시도
    }
}