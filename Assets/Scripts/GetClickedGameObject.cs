using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetClickedGameObject : MonoBehaviour
{

    GameObject clickedGameObject;

    private float timer = 0.5f;

    private float power;
    public Rigidbody rb;
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        power = 30;
        target = GameObject.FindGameObjectWithTag("Enemy");
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {

            clickedGameObject = null;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            if (Physics.Raycast(ray, out hit))
            {
                clickedGameObject = hit.collider.gameObject;

                if (clickedGameObject.tag == "Enemy")
                {
                    Destroy(clickedGameObject, timer);
                    //Destroy(clickedGameObject);

                    //HitTarget();
                }
            }

            Debug.Log(clickedGameObject);
        }
    }



    public void HitTarget()
    {
        transform.LookAt(target.transform);
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward.normalized * power;
    }
}