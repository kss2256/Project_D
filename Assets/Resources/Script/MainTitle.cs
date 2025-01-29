using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainTitle : MonoBehaviour
{


    public void StartButtonClicked()
    {
        Debug.Log("Start_Btuuon Clicked");

        DontDestroyOnLoad(Camera.main.gameObject);

        


        EditorSceneManager.LoadScene("Play Scene");



    }





}
