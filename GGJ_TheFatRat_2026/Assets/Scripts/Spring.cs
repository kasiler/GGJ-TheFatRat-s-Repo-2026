using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    public float springForce;
    public Vector2 normal = new Vector2(0,1);
    public float amplitude = 0.5f;  // 浮动幅度
    public float frequency = 1f;    // 浮动频率
    private Vector3 startPosition;  // 初始位置
    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // 使用正弦函数计算Y轴偏移
        float newY = startPosition.y + Mathf.Sin(Time.time * frequency) * amplitude;
        // 更新物体位置
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }


}
