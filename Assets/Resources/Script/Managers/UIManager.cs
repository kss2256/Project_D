using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class UIManager 
{

    private int m_Order = 10;

    private Stack<UI_PopUp> m_PopUpStack = new Stack<UI_PopUp>();
    private UI_Scene m_SceneUI = null;

    public GameObject Root
    {
        get
        {
            GameObject root = GameObject.Find("@UI_Root");
            if (null == root)
                root = new GameObject("@UI_Root");
            return root;
        }
    }

    public void SetCanvas(GameObject go, bool sort = true)
    {
        Canvas canvas = Util.GetOrAddComponent<Canvas>(go);

        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.overrideSorting = true;

        //설정? 변경 해야할듯
        CanvasScaler scaler = canvas.GetComponent<CanvasScaler>();
        scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        scaler.referenceResolution = new Vector2(1080.0f, 1920.0f);
        scaler.screenMatchMode = CanvasScaler.ScreenMatchMode.Expand;

        if (sort)
        {
            canvas.sortingOrder = m_Order;
            ++m_Order;
        }
        else
        {
            canvas.sortingOrder = 0;
        }


    }
    public T ShowSceneUI<T>(string name = null) where T : UI_Scene
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        GameObject go = Engine.Resource.Instantiate($"Prefabs\\UI\\Scene\\{name}");
        T sceneUI = Util.GetOrAddComponent<T>(go);

        m_SceneUI = sceneUI;

        

        go.transform.SetParent(Root.transform);
        

        return sceneUI;
    }

    public T ShowPopUpUI<T>(string name = null) where T : UI_PopUp
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        GameObject go = Engine.Resource.Instantiate($"Prefabs\\UI\\PopUp\\{name}");
        T popupUI = Util.GetOrAddComponent<T>(go);
        m_PopUpStack.Push(popupUI);


        go.transform.SetParent(Root.transform);

        return popupUI;
    }

    public void ClosePopUpUI(UI_PopUp popup)
    {
        if (m_PopUpStack.Count == 0)
            return;

        if(m_PopUpStack.Peek() != popup)
        {
            Debug.Log("ClosePopUpUI Failed!");
            return;
        }

        CloseAllPopUI();
    }



    public void ClosePopUpUI()
    {
        if (m_PopUpStack.Count == 0)
            return;

        UI_PopUp popup = m_PopUpStack.Pop();
        Engine.Resource.Destory(popup.gameObject);
        popup = null;

        m_Order--;
    }

    public void CloseAllPopUI()
    {
        while (m_PopUpStack.Count > 0)
        {
            ClosePopUpUI();
        }


    }


}
