using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuManager : MonoBehaviour
{
    public bool bgm;
    public bool sound_effect;
    public GameObject obj_mark1;
    public GameObject obj_mark2;
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
        bgm = !bgm;
        obj_mark1.SetActive(bgm);
    }
    public void ClickSoundEffect()
    {
        sound_effect = !sound_effect;
        obj_mark2.SetActive(sound_effect);
    }
    public void gotoLevel1()
    {
        SceneManager.LoadScene("Level1");

    }

}
