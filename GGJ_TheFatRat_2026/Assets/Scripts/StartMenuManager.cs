using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuManager : MonoBehaviour
{
    public bool bgm;
    public bool sound_effect;
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
    public void Load()
    {

    }
    public void Setting()
    {
        SceneManager.LoadScene("settings");

    }
    public void ClickBGM()
    {
        if(bgm)
        {
            bgm = false;
            
        }
        else
        {
            bgm =true;
        }
    }

}
