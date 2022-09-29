using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5.0f;

    Rigidbody rb;

    Vector3 m_EulerAngleVelocity;

    // Start is called before the first frame update
    void Start()
    {
        //Rigidbodyを取得
        rb = GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0, -30, 0);


        m_EulerAngleVelocity = new Vector3(0, 100, 0);
    }

    void Update()
    {

        Vector3 tmp = GameObject.Find("Player").transform.position;

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
        if (Input.GetKey(KeyCode.W))
        {
            //Debug.Log("W");
            rb.velocity = transform.forward * speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            //Debug.Log("S");
            rb.velocity = -transform.forward * speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            //Debug.Log("D");
            //rb.velocity = transform.right * speed;

            Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }
        if (Input.GetKey(KeyCode.A))
        {
            //Debug.Log("A");
            //rb.velocity = -transform.right * speed;

            Quaternion deltaRotation = Quaternion.Euler(-m_EulerAngleVelocity * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }



    }

}