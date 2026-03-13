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
        // 开启走路动画
        anim.SetBool("IsWalk", true);
        transform.position = startPoint.position;
        targetPos = endPoint.position;
        
    }

    void Update()
    {
        // 判断是否到达终点（距离小于0.1则视为到达）（实测发现如果用0.1，角色会一直卡在那里，因为距离计算的是中心的距离）
        if (Vector3.Distance(transform.position, targetPos) > 1.5f)
        {
            
            // 匀速向终点移动（2D中忽略Z轴，保持水平）
            Vector3 moveDir = new Vector3(targetPos.x - transform.position.x, 0, 0).normalized;
            transform.Translate(moveDir * moveSpeed * Time.deltaTime);
        }
        else
        {
            Debug.Log("distance: ");
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