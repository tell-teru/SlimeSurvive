using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPadController : MonoBehaviour
{
    int count = 0;

    public GameObject minSlimePre;


    private float power;
    public Rigidbody rb;
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        power = 30;
        //target = GameObject.FindGameObjectWithTag("Target");
        target = GameObject.Find("Target");
    }

    // Update is called once per frame
    void Update()
    {

        //if()

        //if (Input.GetKeyDown(KeyCode.Space))
        //{ 
            //GameObject obj = Instantiate(minSlimePre, this.position, Quaternion.identity);
            //count++;
            //if (count == 1)
            //{
            //    obj.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            //}
            //if (count == 2)
            //{
            //    obj.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            //}
            //if (count == 3)
            //{
            //    obj.transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);
            //    count = 0;
            //}
        //}
    }


    public void HitTarget()
    {
        transform.LookAt(target.transform);
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward.normalized * power;
    }
}
