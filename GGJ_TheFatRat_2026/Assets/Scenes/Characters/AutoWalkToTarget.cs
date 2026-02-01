using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoWalkToTarget : MonoBehaviour
{
    [Header("移动参数")]
    public Transform startPoint; // 起点空物体
    public Transform endPoint;   // 终点空物体
    public float moveSpeed = 2f; // 移动速度，可自行调整

    [Header("组件引用")]
    private Animator anim;
    private Vector3 targetPos;   // 目标坐标

    void Start()
    {
        // 初始化：获取动画组件，人物回到起点，设置目标为终点
        anim = GetComponent<Animator>();
        transform.position = startPoint.position;
        targetPos = endPoint.position;
        // 开启走路动画
        anim.SetBool("IsWalk", true);
    }

    void Update()
    {
        // 判断是否到达终点（距离小于0.1则视为到达）
        if (Vector3.Distance(transform.position, targetPos) > 0.1f)
        {
            // 匀速向终点移动（2D中忽略Z轴，保持水平）
            Vector3 moveDir = new Vector3(targetPos.x - transform.position.x, 0, 0).normalized;
            transform.Translate(moveDir * moveSpeed * Time.deltaTime);
        }
        else
        {
            // 到达终点：停止移动+关闭走路动画
            anim.SetBool("IsWalk", false);
            gotoTeachLevel();
            enabled = false; // 关闭脚本，避免重复执行
        }
    }
    public void gotoTeachLevel()
    {
        SceneManager.LoadScene("TeachLevel");
    }
}