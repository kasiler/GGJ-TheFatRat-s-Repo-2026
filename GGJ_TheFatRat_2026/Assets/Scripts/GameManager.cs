using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public string levelName;
    public Portal[] portals;
    Scene sc;
    private void Start()
    {
        sc = SceneManager.GetActiveScene();
    }
    private void Update()
    {
        //Time.timeScale = 1.0f;
        if (CheckAllPortals(portals))
        {
            SceneManager.LoadScene(levelName);
        }
        if(Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(sc.name);
        }
    }
    
    public bool CheckAllPortals(Portal[] portals)
    {
        bool result = true;
        foreach (Portal portal in portals)
        {
            if (!portal.character_has_enter) result = false;
        }
        return result;
    }
    
    public void ReloadScene()
    {
        SceneManager.LoadScene(sc.name);
    }

}
