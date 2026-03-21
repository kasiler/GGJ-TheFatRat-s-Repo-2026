using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public string next_levelName;
    public Portal[] portals;
    public UnityEvent OnLevelPass;
    Scene sc;
    
    [Header("fade_to_dark")]
    public Image fadeImage;
    public float fadeSpeed = 1f;
    
    private void Start()
    {
        sc = SceneManager.GetActiveScene();
        
        // 确保初始状态完全透明
        if (fadeImage != null)
        {
            Color color = fadeImage.color;
            color.a = 0f;
            fadeImage.color = color;
        }
    }

    void OnEnable()
    {
        Portal.OnPortalTriggered += CheckAllPortals;
    }
    
    void OnDisable()
    {
        Portal.OnPortalTriggered -= CheckAllPortals;
    }
    
    private void Update()
    {
        if(Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(sc.name);
        }
    }
    
    public void CheckAllPortals()
    {
        foreach (Portal portal in portals)
        {
            if (!portal.character_has_enter) return;
        }
        
        OnLevelPass?.Invoke();
        StartCoroutine(FadeToBlackAndLoadScene());
        return;
    }
    
    IEnumerator FadeToBlackAndLoadScene()
    {
        // 如果fadeImage未设置，直接加载场景
        if (fadeImage == null)
        {
            if(next_levelName != null) SceneManager.LoadScene(next_levelName);
            yield break;
        }
        
        // 逐渐增加透明度直到完全不透明
        Color color = fadeImage.color;
        while (color.a < 1f)
        {
            color.a += Time.deltaTime * fadeSpeed;
            if (color.a > 1f) color.a = 1f;
            fadeImage.color = color;
            yield return null;
        }
        
        // 确保完全变黑
        color.a = 1f;
        fadeImage.color = color;
        
        // 可选：等待一小段时间，让玩家感受游戏结束效果
        yield return new WaitForSeconds(0.3f);
        
        if(next_levelName != null) SceneManager.LoadScene(next_levelName);
    }
    
    public void ReloadScene()
    {
        SceneManager.LoadScene(sc.name);
    }
}