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

        if (other.gameObject.tag == "Enemy")
        {
            slimeScale -= new Vector3(0.1f, 0.1f, 0.1f);//②変数keroのx座標を1増やして代入

            gameObject.transform.localScale = slimeScale; //③大きさに変数keroを代入

            gameObject.transform.position -= new Vector3(0, 0.1f,0);

            Debug.Log("-1");

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
