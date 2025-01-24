using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            SpriteRenderer sr = this.AddComponent<SpriteRenderer>();
            sr.transform.localScale = Engine.Scene.SizeRatio;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            GameObject go = Engine.Resource.Instantiate("Prefabs\\Enemy\\Emeny_A", this.transform);
            go.transform.position = new Vector3(-2.0f, -2.5f, 0.0f);
            go.GetComponent<SpriteRenderer>().sortingOrder = 5;
        }


    }
}
