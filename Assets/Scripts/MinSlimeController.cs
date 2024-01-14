using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinSlimeController : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    //public float speed;

    private PlayerController playerController;

    private Vector3 minslimeScale;  //①仮の変数宣言

    // Start is called before the first frame update
    void Start()
    {
        minslimeScale = this.gameObject.transform.localScale; //◆現在の大きさを代入
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.B))
        { 
            minslimeScale += new Vector3(1.0f, 1.0f, 1.0f);//②変数keroのx座標を1増やして代入

            gameObject.transform.localScale = minslimeScale; //③大きさに変数keroを代入

        }
    }


    
    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Enemy")
        {
            GameObject ene = GameObject.FindWithTag("Enemy");

            
            Destroy(ene);
            Destroy(this);

            Debug.Log("敵を倒した");

        }
    }
}
