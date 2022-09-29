using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinSlimeCreator : MonoBehaviour
{

    public GameObject ballPrefab;
    public float speed;
    public GameObject player;

    PlayerController playerController;


    //public AudioClip sound2;
    //AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        playerController = player.gameObject.GetComponent<PlayerController>();

        //Componentを取得
        //audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shot();

            playerController.slimeScale -= new Vector3(0.1f, 0.1f, 0.1f);//②変数keroのx座標を1増やして代入

            gameObject.transform.localScale = playerController.slimeScale; //③大きさに変数keroを代入

            gameObject.transform.position -= new Vector3(0, 0.1f, 0);

            Debug.Log("-1");
            //audioSource.PlayOneShot(sound2);

            if (playerController.slimeScale == playerController.v0)
            {
                playerController.GameOver();
            }


            playerController.sizeText.text = "S I Z E : " + Mathf.Ceil(playerController.slimeScale.x * 10);
            playerController.armarText.text = "Armar : " + playerController.playerHp;
        }
    }


    public void Shot()
    {
        GameObject ball = (GameObject)Instantiate(ballPrefab, transform.position, Quaternion.identity);
        Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();
        ballRigidbody.AddForce(transform.forward * speed);


        Destroy(ball, 5.0f);
    }

}
