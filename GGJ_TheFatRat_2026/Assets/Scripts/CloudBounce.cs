using UnityEngine;

public class CloudBounce : MonoBehaviour
{
    [Header("云朵弹力（可直接调节）")]
    [Tooltip("建议5-15，根据手感调")]
    public float bounceForce = 10f;
    [Header("防连续弹冷却")]
    public float coolDown = 0.5f;

    private bool canBounce = true;

    // 物理碰撞触发（替代原来的触发检测，不穿模）
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("character") && canBounce)
        {
            Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                canBounce = false;
                Invoke("ResetBounce", coolDown);

                // 重置竖直速度，避免重力影响弹力
                rb.velocity = new Vector2(rb.velocity.x, 0);
                // 水平向左弹（核心，不穿模）
                rb.AddForce(Vector2.left * bounceForce, ForceMode2D.Impulse);
                // 想要左上方弹，替换上行为：
                // rb.AddForce(new Vector2(-bounceForce, bounceForce * 0.4f), ForceMode2D.Impulse);
            }
        }
    }

    private void ResetBounce()
    {
        canBounce = true;
    }
}