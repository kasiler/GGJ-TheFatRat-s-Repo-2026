using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class StartMenuManager : MonoBehaviour
{
    public bool bgm;
    public bool sound_effect;
    public GameObject obj_mark1;
    public GameObject obj_mark2;
    public VideoPlayer videoClip;
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("StartMenu");

        }
    }
    public void NewGame()
    {
        SceneManager.LoadScene("opening");
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void QuitSetting()
    {
        SceneManager.LoadScene("StartMenu");
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
    public void play_final_video()
    {

        videoClip.Play();
    }
    public void ActiveObj(GameObject obj)
    {
        obj.SetActive(true); 
    }

}
