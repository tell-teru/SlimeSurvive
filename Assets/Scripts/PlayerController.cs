using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Vector3 slimeScale;  //①仮の変数宣言


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        slimeScale = gameObject.transform.localScale; //◆現在の大きさを代入
    }

    //public void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Enemy")
    //    {
    //        slimeScale.x = slimeScale.x - 0.1f;  //②変数keroのx座標を1増やして代入
    //        slimeScale.y = slimeScale.y - 0.1f;
    //        slimeScale.z = slimeScale.z - 0.1f;

    //        gameObject.transform.localScale = slimeScale; //③大きさに変数keroを代入

    //        Debug.Log("接触");
    //    }
    //}

    public void OnTriggerEnter(Collider other)
    {
        //Debug.Log(" Hit ");
        if(other.gameObject.tag == "Slime")
        {
            slimeScale.x = slimeScale.x + 0.1f;  //②変数keroのx座標を1増やして代入
            slimeScale.y = slimeScale.y + 0.1f;
            slimeScale.z = slimeScale.z + 0.1f;

            gameObject.transform.localScale = slimeScale; //③大きさに変数keroを代入

            Debug.Log("+1");
            Destroy(other.gameObject);

        }

        if (other.gameObject.tag == "Enemy")
        {
            slimeScale.x = slimeScale.x - 0.1f;  //②変数keroのx座標を1増やして代入
            slimeScale.y = slimeScale.y - 0.1f;
            slimeScale.z = slimeScale.z - 0.1f;

            gameObject.transform.localScale = slimeScale; //③大きさに変数keroを代入

            Debug.Log("-1");

        }
    }
}
