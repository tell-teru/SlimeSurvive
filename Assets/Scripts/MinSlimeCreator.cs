using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinSlimeCreator : MonoBehaviour
{
    public GameObject minSlimePre;
    GameObject Ball;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            //Debug.Log("kurikku");

            Ball = Instantiate(minSlimePre) as GameObject;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 worldDir = ray.direction;
            Ball.GetComponent<MinSlimeController>().Shoot(worldDir.normalized * 3000);
        }
        Destroy(Ball, 10.0f);
    }
}
