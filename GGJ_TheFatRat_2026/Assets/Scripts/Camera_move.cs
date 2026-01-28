using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_move : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public Vector2 xLimit;
    public Vector2 yLimit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = transform.position;
        newPos = Vector3.Lerp(newPos, target.position + offset, 0.1f);
        newPos.x = Mathf.Clamp(newPos.x, xLimit.x, xLimit.y);
        newPos.y = Mathf.Clamp(newPos.y, yLimit.x, yLimit.y);
        transform.position = newPos;
    }
}
