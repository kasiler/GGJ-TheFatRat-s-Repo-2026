using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Dialog_system : MonoBehaviour
{
    [Header("UI组件")]
    public Text textLabel;
    //public Image faceImage;
    [Header("文本文件")]
    public TextAsset textFile;
    [Header("头像")]
    public Image spirit;
    public Image boy;

    public int index;
    public float textSpeed;
    bool textFinished;
    bool cancelTyping;
    static bool talked = false;
    static string last_scene_name;
    List<string> textList = new List<string>();

    void Awake()
    {
        string curr_scene_name = SceneManager.GetActiveScene().name;
        bool is_new_scene = curr_scene_name != last_scene_name;
        last_scene_name = curr_scene_name;
        if(talked == true && is_new_scene == false)
        {
            transform.parent.gameObject.SetActive(false);
        }
        if(is_new_scene == true) talked = false;
        GetTextFromFile(textFile);

    }
    private void OnEnable()
    {
        textFinished = true;
        if(talked == false) StartCoroutine(SetTextUI());
        // textLabel.text = textList[index];
        // index ++;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && index == textList.Count && talked == false)
        {
            talked = true;
            transform.parent.gameObject.SetActive(false);
            index = 0;
        }
        if (Input.GetKeyDown(KeyCode.E) && talked == false)
        {
            if(textFinished && !cancelTyping)
            {
                StartCoroutine(SetTextUI());
            }
            else if (!textFinished && !cancelTyping)
            {
                cancelTyping = true;
            }
        }
    }

    void GetTextFromFile(TextAsset file)
    {
        textList.Clear();
        index = 0;
        var lineData = file.text.Split('\n');
        foreach (string line in lineData)
        {
            textList.Add(line);
            //UnityEngine.Debug.Log(line);
        }
    }

    IEnumerator SetTextUI()
    {
        textFinished = false;
        textLabel.text = "";
        //UnityEngine.Debug.Log(textList[index]);
        switch (textList[index].Trim())
        {
            case "boy":
                //UnityEngine.Debug.Log("walked");
                spirit.gameObject.SetActive(false);
                boy.gameObject.SetActive(true);
                index++;
                break;
            case "spirit":
                boy.gameObject.SetActive(false);
                spirit.gameObject.SetActive(true);
                index++;
                break;
        }
        // if (textList[index] == "boy")
        // {
        //     UnityEngine.Debug.Log("walked");
        //     spirit.gameObject.SetActive(false);
        //     boy.gameObject.SetActive(true);
        //     index++;
        // }

        // for (int i = 0; i < textList[index].Length; i++)
        // {
        //     textLabel.text += textList[index][i];
        //     yield return new WaitForSeconds(textSpeed);
        // }
        int letter = 0;
        while(!cancelTyping && letter < textList[index].Length-1)
        {
            textLabel.text += textList[index][letter];
            letter ++;
            yield return new WaitForSeconds(textSpeed);
        }
        textLabel.text = textList[index];
        cancelTyping = false;
        index ++;
        textFinished = true;
    }
}
