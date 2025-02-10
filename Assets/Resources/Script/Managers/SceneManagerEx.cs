using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SceneType
{
    LOBBY,
    STAGE_1,
    STAGE_2,
    STAGE_3,
    END,
}

public class SceneManagerEx 
{

    private SceneType m_CurSceneType = SceneType.LOBBY;
    private Vector3 m_SizeRatio = Vector3.zero;


    public Vector3 SizeRatio { get { return m_SizeRatio; } }
    public SceneType CurScene { get { return m_CurSceneType; } }

    public void ScreenRatio()
    {
        GameObject go = GameObject.Find(m_CurSceneType.ToString());  
        if(null == go)
        {
            Debug.Log("SceneType Object Null");
        }
        else
        {
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
         

    }

    public GameObject CurSceneObject()
    {
        GameObject go = GameObject.Find(m_CurSceneType.ToString());
        if (null == go)
        {
            Debug.Log("SceneType Object Null");
            return null;
        }
        else
        {
            Transform to = go.transform.Find("Back Ground");
            SpriteRenderer sr = to.gameObject.GetComponent<SpriteRenderer>();

            sr.transform.localScale = m_SizeRatio;
            return to.gameObject;
        } 
    }


    public void NextScene()
    {
        if(m_CurSceneType != SceneType.END)
        ++m_CurSceneType;
        
        if(m_CurSceneType == SceneType.END)
        {
            Debug.Log("END SCENE");            
        }       

        if(m_CurSceneType == SceneType.STAGE_1)
        {
            LoadScene("Play Scene");
            
        }

      
    }

    public void ChangeScene(SceneType scene)
    {
        m_CurSceneType = scene;
        if (m_CurSceneType == SceneType.STAGE_1)
        {       

            LoadScene("Play Scene");           
        }   
    }

    public void LoadScene(string nema, bool nextScene = false)
    {
        if (nextScene)
            ++m_CurSceneType;

        SceneManager.LoadScene(nema);

    }


  

}
