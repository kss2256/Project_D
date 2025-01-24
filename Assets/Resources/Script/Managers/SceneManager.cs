using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum SceneType
{
    TITLE,
    STAGE_1,
    STAGE_2,
    STAGE_3,
    END,
}

public class SceneManager 
{

    private SceneType m_CurScene = SceneType.TITLE;
    private Vector3 m_SizeRatio = Vector3.zero;


    public Vector3 SizeRatio { get { return m_SizeRatio; } }

    private void ScreenRatio()
    {
        GameObject go = GameObject.Find(m_CurScene.ToString());  
        Transform tr = go.transform.Find("Back Ground");

        SpriteRenderer sr = tr.GetComponent<SpriteRenderer>();
        float worldScreenHeight = Camera.main.orthographicSize * 2.0f;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;


        // 가로와 세로의 비율 중 작은 값을 선택
        float widthScale = worldScreenWidth / sr.sprite.bounds.size.x;
        float heightScale = worldScreenHeight / sr.sprite.bounds.size.y;
        float finalScale = Mathf.Min(widthScale, heightScale); // 둘 중 작은 값을 기준으로

        m_SizeRatio = new Vector3(finalScale, finalScale, 1f);       

    }

    public GameObject CurSceneObject()
    {
        GameObject go = GameObject.Find(m_CurScene.ToString());
        Transform to = go.transform.Find("Back Ground");
        SpriteRenderer sr = to.gameObject.GetComponent<SpriteRenderer>();

        sr.transform.localScale = m_SizeRatio;

        return to.gameObject;
    }


    public GameObject NextScene()
    {
        if(m_CurScene != SceneType.END)
        ++m_CurScene;
        
        if(m_CurScene == SceneType.END)
        {
            Debug.Log("END SCENE");
            return null;
        }       
        if(m_CurScene == SceneType.STAGE_1)
        {
            ScreenRatio();
        }

        return CurSceneObject();
    }

    public GameObject ChangeScene(SceneType scene)
    {
        m_CurScene = scene;
        if (m_CurScene == SceneType.STAGE_1)
            ScreenRatio();

        return CurSceneObject();
    }


}
