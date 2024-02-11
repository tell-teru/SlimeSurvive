using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{

    [SerializeField]
    GameObject button;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickButtonSceneMove()
    {
        if (SceneManager.GetActiveScene().name == "Title")
        {
            SceneManager.LoadScene("Rule");
        }
        if (SceneManager.GetActiveScene().name == "Rule")
        {
            SceneManager.LoadScene("Main");
        }

        if (SceneManager.GetActiveScene().name == "GameOver")
        {
            SceneManager.LoadScene("Main");
        }

        if (SceneManager.GetActiveScene().name == "Clear")
        {
            SceneManager.LoadScene("Title");
        }
    }
}
