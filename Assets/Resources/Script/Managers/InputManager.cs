using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager 
{

    public Action _Action = null;



    public void MouseCheak()
    {

        if (Input.anyKey == false)
            return;

        if (null != _Action)
        {
            _Action.Invoke();

            Debug.Log("Mouse Cheak");
        }



    }






}
