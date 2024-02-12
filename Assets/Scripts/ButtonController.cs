using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{

    [SerializeField]
    GameObject button;

    private float initialAlpha = 0.2f;

    // 点滅の間隔
    [SerializeField]
    private float blinkInterval = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        initialAlpha = button.GetComponent<Image>().color.a;
        StartBlinkAnimation();
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
            SceneManager.LoadScene("Main");
        }
    }

    public void OnClickBackButton()
    {
        if (SceneManager.GetActiveScene().name == "Rule")
        {
            SceneManager.LoadScene("Title");
        }
        if (SceneManager.GetActiveScene().name == "Clear")
        {
            SceneManager.LoadScene("Title");
        }
        if (SceneManager.GetActiveScene().name == "GameOver")
        {
            SceneManager.LoadScene("Title");
        }
    }

    void StartBlinkAnimation()
    {
        // DOTweenを使用して透明度を変化させるアニメーションを作成
        button.GetComponent<Image>().DOFade(0.2f, blinkInterval)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Yoyo);
    }
}
