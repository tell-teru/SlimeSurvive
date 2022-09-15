using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    PlayerController pCon;
    //public GameObject player;

    bool gameOverBool;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Title")
        {
            if (Input.GetMouseButton(0))
            {
                SceneManager.LoadScene("Main");
            }
        }

        if (SceneManager.GetActiveScene().name == "GameOver")
        {
            if (Input.GetMouseButton(0))
            {
                SceneManager.LoadScene("Main");
            }
        }

        if (SceneManager.GetActiveScene().name == "Clear")
        {
            if (Input.GetMouseButton(0))
            {
                SceneManager.LoadScene("Title");
            }
        }


        //if (SceneManager.GetActiveScene().name == "Main")
        //{
        //    if(gameOverBool == true)
        //    {
        //        Debug.Log("Bool");
        //        if (Input.GetKey(KeyCode.Space))
        //        {
        //            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //        }
        //    }

        //}
    }
}
