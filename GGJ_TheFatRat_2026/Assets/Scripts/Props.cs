using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Props : MonoBehaviour
{
    [Header("show_image")]
    public Image scene_Image;
    public float showSpeed = 1f;
    [Header("fluctuate")]
    public float amplitude = 0.5f;  // 浮动幅度
    public float frequency = 1f;    // 浮动频率
    private Vector3 startPosition;  // 初始位置
    public int rdNum = 0;
    void Start()
    {
        startPosition = transform.position;
        if (rdNum == 0)
        {
            rdNum = UnityEngine.Random.Range(0, 6);
        }
        if (scene_Image != null)
        {
            Color color = scene_Image.color;
            color.a = 0f;
            scene_Image.color = color;
        }
    }

    void Update()
    {
        // 使用正弦函数计算Y轴偏移
        float newY = startPosition.y + Mathf.Sin(Time.time * frequency + rdNum) * amplitude;
        // 更新物体位置
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }
    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        if (otherObject.gameObject.tag == "character")
        {
            Debug.Log("destroy!");
            StartCoroutine(showMemoryScene());
        }
        return;
    }
    IEnumerator showMemoryScene()
    {
        if (scene_Image == null) yield break;
        Color color = scene_Image.color;
        while (color.a < 1f)
        {
            color.a += Time.deltaTime * showSpeed;
            if (color.a > 1f) color.a = 1f;
            scene_Image.color = color;
            yield return null;
        }
        // 确保完全不透明
        color.a = 1f;
        scene_Image.color = color;

        yield return new WaitForSeconds(0.2f);


        //然后再变透明
        while (color.a > 0f)
        {
            color.a -= Time.deltaTime * showSpeed;
            if (color.a < 0f) color.a = 0f;
            scene_Image.color = color;
            yield return null;
        }
        
        // 确保完全不透明
        color.a = 0f;
        scene_Image.color = color;

        gameObject.SetActive(false);
    }
}
