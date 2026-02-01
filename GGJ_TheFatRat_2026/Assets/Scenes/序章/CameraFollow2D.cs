using UnityEngine;

/// <summary>
/// 2D镜头跟随胶囊体，平滑跟随+边界限制可选
/// </summary>
public class CameraFollow2D : MonoBehaviour
{
    [Header("跟随目标")]
    public Transform target; // 拖入胶囊体对象
    [Header("跟随参数")]
    public float smoothSpeed = 5f; // 平滑跟随速度，越大越跟得紧
    public Vector3 offset; // 镜头与目标的偏移量（可手动调上下左右）

    void LateUpdate()
    {
        // 若无目标则直接返回，避免报错
        if (target == null) return;

        // 计算目标镜头位置（固定Z轴，保持相机深度，2D必加）
        Vector3 targetCamPos = target.position + offset;
        targetCamPos.z = transform.position.z;

        // 平滑移动镜头（无平滑则直接赋值：transform.position = targetCamPos;）
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothSpeed * Time.deltaTime);
    }
}