using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Slime")
        {
            Debug.Log("接触");
            Destroy(collision.gameObject);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(" Hit ");
        if(other.gameObject.tag == "Slime")
        {
            Debug.Log("HIT");
            Destroy(other.gameObject);
        }
    }
}
