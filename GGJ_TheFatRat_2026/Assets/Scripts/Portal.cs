using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] int next_level;
    public bool character_has_enter = false;


    [Header("fluctuate")]
    public float amplitude = 0.5f;  // 浮动幅度
    public float frequency = 1f;    // 浮动频率
    private Vector3 startPosition;  // 初始位置
    public int rdNum = 0;

    public static Action OnPortalTriggered;
    void Start()
    {
        startPosition = transform.position;
        if (rdNum == 0)
        {
            rdNum = UnityEngine.Random.Range(0, 6);
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
            character_has_enter = true;
            OnPortalTriggered?.Invoke();
        }
    }
    private void OnTriggerExit2D(Collider2D otherObject)
    {
        if (otherObject.gameObject.tag == "character")
        {
            character_has_enter = false;
        }
    }
}
