using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class ButtonAnimationController : MonoBehaviour
{
    [SerializeField]
    GameObject menuButton;

    [SerializeField]
    GameObject menuWindow;

    [SerializeField]
    GameObject menuCanvas;

    [SerializeField]
    GameObject ruleButton;

    [SerializeField]
    GameObject quitButton;

    [SerializeField]
    GameObject backButton;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMenuButtonClick()
    {
        menuButton.transform.DOPunchScale(Vector3.one * 0.1f, 0.3f)
            .SetEase(Ease.OutQuad);
        ShowWindow();
    }

    void ShowWindow()
    {
        menuCanvas.SetActive(true);
        menuWindow.SetActive(true);
        menuWindow.transform.localScale = Vector3.zero;
        menuWindow.transform.DOScale(new Vector3(0.8f, 1.7f, 1), 1.7f)
            .SetEase(Ease.OutBounce);
    }

    void CloseWindow()
    {
        menuWindow.transform.localScale = new Vector3(0.8f, 1.7f, 1); // 初期スケールを設定
        menuWindow.transform.DOScale(Vector3.zero, 0.7f)
            .SetEase(Ease.OutQuad)
            .OnComplete(SetMenuWindow);
    }

    public void OnRuleButtonClick()
    {
        ruleButton.transform.DOPunchScale(Vector3.one * 0.1f, 0.3f)
            .SetEase(Ease.OutQuad)
            .OnComplete(SendRuleScene);
        
    }

    public void OnQuitButtonClick()
    {
        quitButton.transform.DOPunchScale(Vector3.one * 0.1f, 0.3f)
            .SetEase(Ease.OutQuad)
            .OnComplete(EndGame);
        
    }

    public void OnBackButtonClick()
    {
        backButton.transform.DOPunchScale(Vector3.one * 0.1f, 0.3f)
            .SetEase(Ease.OutQuad)
            .OnComplete(CloseWindow);
    }

    private void SetMenuWindow()
    {
        menuWindow.SetActive(false);
        menuCanvas.SetActive(false);
    }

    private void SendRuleScene()
    {
        SceneManager.LoadScene("Rule");
    }

    // ゲーム終了
    private void EndGame()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
        #else
                Application.Quit();//ゲームプレイ終了
        #endif
    }

}
