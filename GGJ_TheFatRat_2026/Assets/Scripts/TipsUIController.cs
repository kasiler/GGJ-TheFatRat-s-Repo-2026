using UnityEngine;
using UnityEngine.UI;

public class TipsUIController : MonoBehaviour
{
    // 拖拽赋值：把Hierarchy中的TipsButton和TipsPanel拖到对应槽位
    public GameObject tipsButton;
    public GameObject tipsPanel;
    // 关闭按钮（需在Inspector中拖拽赋值）
    public GameObject closeButton;

    void Start()
    {
        // 初始隐藏Tips面板
        tipsPanel.SetActive(false);
        // 给Tips按钮绑定点击事件（点击显示/隐藏）
        //tipsButton.onClick.AddListener(ToggleTipsPanel);
        // 给关闭按钮绑定点击事件
        //closeButton.onClick.AddListener(HideTipsPanel);
    }

    // 切换Tips面板显示/隐藏（点一次显示，再点一次隐藏）
    public void ToggleTipsPanel()
    {
        tipsPanel.SetActive(!tipsPanel.activeSelf);
    }

    // 单独隐藏面板（给关闭按钮用）
    public void CloseTipsPanel()
    {
        tipsPanel.SetActive(false);
    }
}