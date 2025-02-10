using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraResolution : MonoBehaviour
{



    //세로 기준으로 크기 맞춰보기
    //void Start()
    //{
    //    SpriteRenderer sr = GetComponent<SpriteRenderer>();
    //    float worldScreenHeight = Camera.main.orthographicSize * 2.0f;
    //    float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

    //    Vector3 scale = transform.localScale;
    //    scale.x = worldScreenWidth / sr.sprite.bounds.size.x;
    //    scale.y = worldScreenHeight / sr.sprite.bounds.size.y;
    //    transform.localScale = scale;
    //}

    //가로 기준으로 크기 맞춰보기
    //void Start()
    //{
    //    SpriteRenderer sr = GetComponent<SpriteRenderer>();

    //    // 화면의 가로 크기를 계산 (World 기준)
    //    float worldScreenWidth = Camera.main.orthographicSize * 2.0f * Screen.width / Screen.height;

    //    // 가로를 기준으로 스프라이트 크기를 맞춤
    //    Vector3 scale = transform.localScale;
    //    scale.x = worldScreenWidth / sr.sprite.bounds.size.x;
    //    scale.y = scale.x; // 비율을 유지하기 위해 가로와 같은 비율로 설정
    //    transform.localScale = scale;
    //}


    public float m_Speed = 0.0f;
    public Vector3 m_MovePos = Vector3.zero;
    public bool m_MoveCamera = false;

    private void Start()
    {
      



    }

   
    private void Update()
    {
        //Test Function
        if(Input.GetKey(KeyCode.Q))
        {
           
        }


        if(m_MoveCamera)
        {
            MoveCamera();
        }


    }

    void CheckRoute(GameObject go)
    {        
        m_MovePos = go.transform.position;
        m_MovePos.z = -10.0f;
        m_MoveCamera = true;
    }
    void MoveCamera()
    {
        
        Vector3 dir = m_MovePos - transform.position;

        if (dir.magnitude < 0.0001f)
        {
            m_MoveCamera = false;
        }
        else
        {
            float moveDist = Mathf.Clamp(m_Speed * Time.deltaTime, 0, dir.magnitude);
            transform.position += dir.normalized * moveDist;
        }

    }

}
