using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinSlimeController : MonoBehaviour
{
    public GameObject ballPrefab;
    public float speed;

    PlayerController playerController;


    public AudioClip sound2;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    
    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Enemy")
        {
            GameObject ene = GameObject.FindWithTag("Enemy");

            //playerController.slimeScale -= new Vector3(0.1f, 0.1f, 0.1f);//②変数keroのx座標を1増やして代入

            //gameObject.transform.localScale = playerController.slimeScale; //③大きさに変数keroを代入

            //gameObject.transform.position -= new Vector3(0, 0.1f, 0);

            //Debug.Log("-1");
            //audioSource.PlayOneShot(sound2);

            //if (playerController.slimeScale == playerController.v0)
            //{
            //    playerController.GameOver();
            //}

            Destroy(ene);

            Debug.Log("敵を倒した");

        }
    }
}
