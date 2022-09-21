using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinSlimeController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot(Vector3 dir)
    {
        Debug.Log("kurikku");

        GetComponent<Rigidbody>().AddForce(dir);
    }

    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Enemy")
        {
            GameObject ene = GameObject.FindWithTag("Enemy");

            Destroy(ene);

            Debug.Log("敵を倒した");

        }
    }
}
