using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] public float jumpForce = 4.5f;
    private bool isGround = true;
    //public static bool isGround = true;
    [SerializeField] SpriteRenderer Spirit_SR;
    [SerializeField] Rigidbody2D Spirit_RB;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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
                isGround = false;
                Spirit_RB.velocity = new Vector3(0, jumpForce, 0);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D otherObject)
    {
        if (otherObject.gameObject.tag == "Ground")
        {
            Debug.Log("撞到了！");
            if (otherObject.contacts[0].normal == new Vector2(0, 1))
            {
                isGround = true;
            }
        }
        if (otherObject.gameObject.tag == "Spring")
        {
            Debug.Log("碰到了弹簧！");

            if (otherObject.contacts[0].normal == new Vector2(0, 1))
            {
                //float springForce = otherObject.gameObject.springForce;
                GetComponent<Rigidbody2D>().velocity = new Vector3(0, 7.5f, 0);
                isGround = false;
                Spirit_RB.velocity = new Vector3(0, 7.5f, 0);

            }
        }
        //if (otherObject.gameObject.tag == "deadLine")
        //{
        //    Debug.Log("挂了！");
        //}
    }
    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        //if (otherObject.gameObject.tag == "deadLine")
        //{
        //    Debug.Log("挂了！");
        //}
    }
    //void GroundDetection()
    //{
    //    Collider2D hit = Physics2D.OverlapCircle(transform.position + detectionOffset, detectionRadius, groundLayer);
    //    if (hit != nul1)
    //    {
    //        isGround = true;
    //    }
    //    else
    //    {
    //        isGround = false;
    //    }
    //}

}