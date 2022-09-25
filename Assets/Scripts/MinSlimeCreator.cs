using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinSlimeCreator : MonoBehaviour
{
    public GameObject minSlimePre;
    GameObject Ball;

    // インスペクタから直接、親オブジェクトを指定するとか
    public GameObject parentObject;




    //public GameObject player;
    Vector3 position;


    // Start is called before the first frame update
    void Start()
    {

        GameObject player = GameObject.FindGameObjectWithTag("Player");//Playerタグのオジェクトを探して
        position = player.transform.position;

        // タグ名から親オブジェクトを探して取得するとか
        //GameObject parentObject = GameObject.FindGameObjectWithTag("ParentObject");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("kurikku");

            //// prefabObjectにはプレハブが指定されているとします
            //GameObject childObject = Instantiate(prefabObject) as GameObject;
            //childObject.transform.parent = parentObject.transform;


            //Ball = Instantiate(minSlimePre) as GameObject;
            Ball = Instantiate(minSlimePre, position, Quaternion.identity);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 worldDir = ray.direction;
            Ball.GetComponent<MinSlimeController>().Shoot(worldDir.normalized * 3000);
        }
        Destroy(Ball, 10.0f);



    }

    private GameObject Instantiate(GameObject minSlimePre, object parent, Quaternion identity)
    {
        throw new NotImplementedException();
    }
}
