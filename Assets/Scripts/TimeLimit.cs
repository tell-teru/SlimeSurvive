using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TimeLimit : MonoBehaviour
{
    private Image timeObj;
    private float countTime = 30.0f;
    private float time = 0.0f;
    private bool isBlue = true; // 初期状態は青
    private Vector3 originalScale; // オリジナルのスケール

    // Start is called before the first frame update
    void Start()
    {
        timeObj = GetComponent<Image>();
        originalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time >= countTime)
        {
            SwitchColor();
            time = 0.0f;
        }

        UpdateTimerColor();
        UpdateTimerFillAmount();
    }

    private void SwitchColor()
    {
        isBlue = !isBlue; // 色を交互に切り替える
    }

    private void UpdateTimerColor()
    {
        if (isBlue)
            timeObj.color = Color.cyan;
        else
            timeObj.color = Color.red;
    }

    private void UpdateTimerFillAmount()
    {
        timeObj.fillAmount -= (1.0f / countTime) * Time.deltaTime;

        if (timeObj.fillAmount <= 0.0f)
        {
            ResetTimer();
        }
    }

    private void ResetTimer()
    {
        timeObj.fillAmount = 1.0f;


        //transform.DOMove(transform.position, 1.0f)
        //    .From(new Vector3(Screen.width / 2, Screen.height / 2, 0))
        //    .SetEase(Ease.OutBounce);
        transform.DOScale(new Vector3(4,7,1), 0f);

        transform.DOMove(transform.position, 1.0f)
            .From(new Vector3(Screen.width / 2, Screen.height / 2, 0))
            .SetEase(Ease.OutCirc)
            .OnComplete(() =>
                transform.DOScale(originalScale, 0.5f)
                .SetEase(Ease.OutQuart)
            );

    }
}
