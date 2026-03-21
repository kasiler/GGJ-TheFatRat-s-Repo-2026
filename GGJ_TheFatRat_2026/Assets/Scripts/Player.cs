using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] public float jumpForce;
    private bool isGround = false;
    [SerializeField] SpriteRenderer Spirit_SR;
    [SerializeField] Rigidbody2D Spirit_RB;
    public float is_same_direction = -1;
    private Vector3 deadPosition;
    private Vector3 deadVelocity;
    private Rigidbody2D rb;
    private Vector3 currentScale;


    [Header("Ground Check")]
    public Vector3 detectionOffset;
    public float detectionRadius;
    public LayerMask groundLayer;


    void Start()
    {

    }

    void Update()
    {
        GroundDetection();
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
            currentScale = transform.localScale;
            currentScale.x = Mathf.Abs(currentScale.x);
            transform.localScale = currentScale;
            detectionOffset.x = -Mathf.Abs(detectionOffset.x);
            Spirit_SR.transform.Translate(-moveSpeed * Time.deltaTime * (-is_same_direction), 0, 0);
            GetComponent<Animator>().SetBool("Run", true);
            if(is_same_direction == -1f)
            {
                Spirit_SR.flipX = true;
            }
            else
            {
                Spirit_SR.flipX = false;
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
            currentScale = transform.localScale;
            currentScale.x = -Mathf.Abs(currentScale.x);
            transform.localScale = currentScale;
            detectionOffset.x = Mathf.Abs(detectionOffset.x);
            Spirit_SR.transform.Translate(moveSpeed * Time.deltaTime * (-is_same_direction), 0, 0);
            GetComponent<Animator>().SetBool("Run", true);
            if (is_same_direction == -1)
            {
                Spirit_SR.flipX = false;
            }
            else
            {
                Spirit_SR.flipX = true;
            }
        }
        else
        {
            GetComponent<Animator>().SetBool("Run", false);
        }
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && isGround)
        {
            //让玩家和幽灵跳起来
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, jumpForce, 0);
            Spirit_RB.velocity = new Vector3(0, jumpForce, 0);
            GetComponent<Animator>().SetBool("Jump", true);
            GetComponent<AudioSource>().Play();
                
        }
        else if(!isGround)
        {
            GetComponent<Animator>().SetBool("Jump", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("Jump", false);
        }
    }
    private void OnCollisionEnter2D(Collision2D otherObject)
    {
        if (otherObject.gameObject.tag == "Ground")
        {

        }
        if (otherObject.gameObject.tag == "Spring")
        {
            Debug.Log("碰到了弹簧！");
            Vector2 normal = otherObject.gameObject.GetComponent<Spring>().normal;
            if (otherObject.contacts[0].normal == normal)
            {
                float springForce = otherObject.gameObject.GetComponent<Spring>().springForce;
                GetComponent<Rigidbody2D>().velocity = new Vector2(springForce*normal.x, springForce*normal.y);
                isGround = false;
                GetComponent<AudioSource>().Play();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        if (otherObject.gameObject.tag == "deadLine")
        {
            deadPosition = transform.position;
            rb = GetComponent<Rigidbody2D>();
            deadVelocity = rb.velocity;
            rb.velocity = new Vector3(deadVelocity.x, 0 ,deadVelocity.z);
            transform.position = new Vector3(deadPosition.x, 9.5f, deadPosition.z);
        }
    }
    void GroundDetection()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position + detectionOffset, detectionRadius, groundLayer);
        if (hit != null)
        {
            isGround = true;
            //当角色落地的时候，手再插兜
            Transform body = transform.Find("body");
            body.gameObject.SetActive(true);
            Transform forearm = transform.Find("forearm");
            forearm.gameObject.SetActive(false);
            Transform body_noarm = transform.Find("body_noarm");
            body_noarm.gameObject.SetActive(false);
        }
        else
        {
            isGround = false;
            //将玩家的body隐藏，然后让手和没有手的body亮出来
            Transform body = transform.Find("body");
            body.gameObject.SetActive(false);
            Transform forearm = transform.Find("forearm");
            forearm.gameObject.SetActive(true);
            Transform body_noarm = transform.Find("body_noarm");
            body_noarm.gameObject.SetActive(true);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + detectionOffset, detectionRadius);
    }

}