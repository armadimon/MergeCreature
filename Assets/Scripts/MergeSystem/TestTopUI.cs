using System.Collections;
using System.Collections.Generic;
using TMPro;
using UniRx;
using UnityEngine;

public class TestTopUI : UIBase
{
    public TextMeshProUGUI text;

    private void Awake()
    {
        UIManager.OnUIChanged
            .Where(ui => ui != null)
            .Subscribe(ui =>
            {
                text.text = $"{ui.name}";
            })
            .AddTo(this);
    }

    public override void Opened(params object[] args)
    {
        // text.text = args[0] as string;
    }

    public override void HideDirect()
    {
    }
}