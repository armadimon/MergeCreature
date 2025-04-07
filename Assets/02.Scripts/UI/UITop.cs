using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UITop : UIBase
{
    public TextMeshProUGUI text;
    
    public override void Opened(params object[] args)
    {
        text.text = args[0] as string;
    }
    
    public override void HideDirect()
    {
    }

}
