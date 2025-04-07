using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class MergePresenter
{
    private readonly MergeBoardView _view;
    private readonly MergeSystem _mergeSystem;

    public MergePresenter(MergeBoardView view, MergeSystem mergeSystem)
    {
        _view = view;
        _mergeSystem = mergeSystem;

        // 머지가 성공하면 UI 업데이트
        _mergeSystem.OnMergeSuccess
            .Subscribe(result => _view.UpdateBoard(result))
            .AddTo(_view);
    }
}
