using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    Vector3 slimeScale;  //①仮の変数宣言
    Vector3 v0 = new Vector3(0.0f, 0.0f, 0.0f);

    public GameObject gameOverText;
    public bool gameOver;

    private int playerHp = 0;


    // Start is called before the first frame update
    void Start()
    {
        slimeScale = gameObject.transform.localScale; //◆現在の大きさを代入


        gameOverText.gameObject.SetActive(false);
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(slimeScale == v0)
        {
            GameOver();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        //Debug.Log(" Hit ");
        if(other.gameObject.tag == "Slime")
        {
            slimeScale += new Vector3(0.1f, 0.1f, 0.1f);//②変数keroのx座標を1増やして代入

            gameObject.transform.localScale = slimeScale; //③大きさに変数keroを代入

            gameObject.transform.position += new Vector3(0, 0.1f, 0);

            Debug.Log("+1");
            Destroy(other.gameObject);

        }

        if (other.gameObject.tag == "Armar")
        {

            slimeScale += new Vector3(0.3f, 0.3f, 0.3f);//②変数keroのx座標を1増やして代入

            gameObject.transform.localScale = slimeScale; //③大きさに変数keroを代入

            gameObject.transform.position += new Vector3(0, 0.3f, 0);

            Debug.Log("+3");
            Destroy(other.gameObject);

        }

        if (other.gameObject.tag == "Helmet")
        {
            playerHp += 3;

            Debug.Log("HP+3");
            Destroy(other.gameObject);

        }

        if (other.gameObject.tag == "King")
        {
            playerHp += 5;

            slimeScale += new Vector3(1.0f, 1.0f, 1.0f);//②変数keroのx座標を1増やして代入

            gameObject.transform.localScale = slimeScale; //③大きさに変数keroを代入

            gameObject.transform.position += new Vector3(0, 1.0f, 0);

            Debug.Log("+10");
            Destroy(other.gameObject);

        }

        if (other.gameObject.tag == "Enemy")
        {

            if(playerHp == 0)
            {
                slimeScale -= new Vector3(0.1f, 0.1f, 0.1f);//②変数keroのx座標を1増やして代入

                gameObject.transform.localScale = slimeScale; //③大きさに変数keroを代入

                gameObject.transform.position -= new Vector3(0, 0.1f, 0);

                Debug.Log("-1");
            }
            else if(playerHp != 0)
            {
                playerHp -= 1;
                Debug.Log("HP : " + playerHp);
            }
            

        }
    }

    void GameOver()
    {
        Debug.Log("GameOver");

        gameOverText.gameObject.SetActive(true);
        gameOver = true;

        SceneManager.LoadScene("GameOver");
    }
}
