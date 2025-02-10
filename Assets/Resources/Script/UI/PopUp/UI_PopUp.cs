using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_PopUp : UI_Base
{

    public virtual void Init()
    {
        Engine.UI.SetCanvas(gameObject, true);

    }


    public virtual void ClosePopUpUI()
    {
        Engine.UI.ClosePopUpUI(this);
    }


}
