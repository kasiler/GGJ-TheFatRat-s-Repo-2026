using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] public float jumpForce = 4.5f;
    private bool isGround = false;
    [SerializeField] SpriteRenderer Spirit_SR;
    [SerializeField] Rigidbody2D Spirit_RB;
    private Vector3 deadPosition;
    private Vector3 deadVelocity;
    private Rigidbody2D rb;


    [Header("Ground Check")]
    public Vector3 detectionOffset;
    public float detectionRadius = 0.2f;
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
            GetComponent<SpriteRenderer>().flipX = false;
            Spirit_SR.transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
            Spirit_SR.flipX = true;
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
            GetComponent<SpriteRenderer>().flipX = true;
            Spirit_SR.transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
            Spirit_SR.flipX = false;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            if (isGround)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector3(0, jumpForce, 0);
                Spirit_RB.velocity = new Vector3(0, jumpForce, 0);
            }
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
            if (otherObject.contacts[0].normal == new Vector2(0, 1))
            {
                //float springForce = otherObject.gameObject.springForce;
                GetComponent<Rigidbody2D>().velocity = new Vector3(0, 10.5f, 0);
                isGround = false;

            }
        }
        //if (otherObject.gameObject.tag == "deadLine")
        //{
        //    Debug.Log("挂了！");
        //}
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
            Debug.Log("挂了！");
        }
    }
    void GroundDetection()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position + detectionOffset, detectionRadius, groundLayer);
        if (hit != null)
        {
            isGround = true;
        }
        else
        {
            isGround = false;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + detectionOffset, detectionRadius);
    }

}