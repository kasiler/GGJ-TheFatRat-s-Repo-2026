using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuManager : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void NewGame()
    {
        SceneManager.LoadScene("opening");
    }
    public void Quit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
