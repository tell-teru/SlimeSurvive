using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinSlimeCreator : MonoBehaviour
{
    public GameObject minSlimePre;
    GameObject Ball;

    public GameObject player;
    Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");//Playerタグのオジェクトを探して
        position = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("kurikku");

            

            //Ball = Instantiate(minSlimePre) as GameObject;
            Ball = Instantiate(minSlimePre, position, Quaternion.identity);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 worldDir = ray.direction;
            Ball.GetComponent<MinSlimeController>().Shoot(worldDir.normalized * 3000);
        }
        Destroy(Ball, 10.0f);
    }
}
