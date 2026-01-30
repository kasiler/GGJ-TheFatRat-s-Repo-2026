using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Spirit : MonoBehaviour
{
    // Start is called before the first frame update
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
            Debug.Log("撞到了！");
        }
        if (otherObject.gameObject.tag == "deadLine")
        {
            Debug.Log("挂了！");
        }
    }
    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        if (otherObject.gameObject.tag == "deadLine")
        {
            Debug.Log("挂了！");
        }
    }
}
