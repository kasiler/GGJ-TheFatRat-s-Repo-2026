using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Spirit : MonoBehaviour
{
    private Vector3 deadPosition;
    private Vector3 deadVelocity;
    private Rigidbody2D rb;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        //{
        //    //Thread.Sleep(1000);
        //    transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
        //    GetComponent<SpriteRenderer>().flipX = true;
        //}
        //if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        //{
        //    //Thread.Sleep(1000);
        //    transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
        //    GetComponent<SpriteRenderer>().flipX = false;

        //}
        //if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        //{
        //    GetComponent<Rigidbody2D>().velocity = new Vector3(0, 4.5f, 0);
        //}
    }
    private void OnCollisionEnter2D(Collision2D otherObject)
    {
        if (otherObject.gameObject.tag == "Ground")
        {
            //Debug.Log("撞到了！");
        }
        if (otherObject.gameObject.tag == "Spring")
        {
            //Debug.Log("碰到了弹簧！");

            if (otherObject.contacts[0].normal == new Vector2(0, 1))
            {
                //float springForce = otherObject.gameObject.springForce;
                GetComponent<Rigidbody2D>().velocity = new Vector3(0, 10.5f, 0);

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
            rb.velocity = new Vector3(deadVelocity.x, 0, deadVelocity.z);
            transform.position = new Vector3(deadPosition.x, 9.5f, deadPosition.z);
            Debug.Log("挂了！");
        }
    }
}
