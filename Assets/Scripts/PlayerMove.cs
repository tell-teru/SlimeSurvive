using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 1.0f;

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //Debug.Log("↑");
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            //Debug.Log("↓");
            transform.position -= transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //Debug.Log("→");
            transform.position += transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //Debug.Log("←");
            transform.position -= transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            //Debug.Log("W");
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            //Debug.Log("S");
            transform.position -= transform.forward * speed * Time.deltaTime;
        }
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

    }

}