using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinSlimeController : MonoBehaviour
{
    public GameObject ballPrefab;
    //public float speed;

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

            
            Destroy(ene);
            Destroy(this);

            Debug.Log("敵を倒した");

        }
    }
}
