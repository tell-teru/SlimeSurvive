using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5.0f;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        //Rigidbodyを取得
        rb = GetComponent<Rigidbody>();

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.velocity = transform.forward * speed;
            //rb.AddForce(transform.forward * speed);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            //Debug.Log("↓");
            //transform.position -= transform.forward * speed * Time.deltaTime;
            rb.velocity = -transform.forward * speed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //Debug.Log("→");
            //transform.position += transform.right * speed * Time.deltaTime;
            rb.velocity = transform.right * speed;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //Debug.Log("←");
            //transform.position -= transform.right * speed * Time.deltaTime;
            rb.velocity = -transform.right * speed;
        }
        //if (Input.GetKey(KeyCode.W))
        //{
        //    //Debug.Log("W");
        //    transform.position += transform.forward * speed * Time.deltaTime;
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    //Debug.Log("S");
        //    transform.position -= transform.forward * speed * Time.deltaTime;
        //}
        if (Input.GetKey(KeyCode.D))
        {
            //Debug.Log("D");
            //transform.position += transform.right * speed * Time.deltaTime;
            transform.Rotate(new Vector3(0, 1, 0));
        }
        if (Input.GetKey(KeyCode.A))
        {
            //Debug.Log("A");
            //transform.position -= transform.right * speed * Time.deltaTime;
            transform.Rotate(new Vector3(0, -1, 0));
        }


        //// 入力をxとzに代入
        //float x = Input.GetAxis("Horizontal");
        //float z = Input.GetAxis("Vertical");


        //////Rigidbodyを取得
        ////Rigidbody rb = GetComponent<Rigidbody>();

        ////Rigidbodyに力を加える
        //rb.AddForce(x, 0, z);

    }

}