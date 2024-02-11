using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class WaveManager : MonoBehaviour
{
    private float waveTimer = 0;

    [SerializeField] private GameObject slimeCreater;
    [SerializeField] private GameObject enemyCreater;
    [SerializeField] private GameObject MinSlimeGenerator;

    public bool nowWave = false;

    private int waveCount = 0;


    [SerializeField] private Text waveText;
    [SerializeField] private GameObject waveCanvas;
    [SerializeField] private GameObject warning;

    //Camera
    [SerializeField] private Transform tf; //Main CameraのTransform
    [SerializeField] private Transform player;

    private float initialAlpha = 0.2f;
    // 点滅の間隔
    [SerializeField]
    private float blinkInterval = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        WaveSwitch();
        initialAlpha = waveCanvas.GetComponent<Text>().color.a;

        //Camera
        tf = tf.gameObject.GetComponent<Transform>(); //Main CameraのTransformを取得する。
        player = this.GetComponent<Transform>(); //Main CameraのTransformを取得する。
    }

    // Update is called once per frame
    void Update()
    {
        waveTimer += Time.deltaTime;

        if(waveTimer >= 30.0f)
        {
            WaveSwitch();
            waveTimer = 0;
        }

        if(waveCount == 4)//waveCount=2 で1WAVE生き残りゲームに　=4で３WAVE生き残りゲームになる
        {
            Clear();
        }
    }

    void WaveSwitch()
    {
        if (nowWave == true)
        {
            //文字うきだし
            waveCanvas.gameObject.SetActive(true);
            // DOTweenを使用して透明度を変化させるアニメーションを作成
            waveCanvas.GetComponent<Text>()
                .DOFade(0.2f, blinkInterval)
                .SetEase(Ease.Linear)
                .SetLoops(2, LoopType.Yoyo)
                .OnComplete(StartCoroutine);

            //クローン一気に消す
            var slimClones = GameObject.FindGameObjectsWithTag("Slime");
            foreach(var clone in slimClones)
            {
                Destroy(clone);
            }

            var armarClones = GameObject.FindGameObjectsWithTag("Armar");
            foreach (var clone in armarClones)
            {
                Destroy(clone);
            }

            var helClones = GameObject.FindGameObjectsWithTag("Helmet");
            foreach (var clone in helClones)
            {
                Destroy(clone);
            }

            var kingClones = GameObject.FindGameObjectsWithTag("King");
            foreach (var clone in kingClones)
            {
                Destroy(clone);
            }

            enemyCreater.gameObject.SetActive(true);
            slimeCreater.gameObject.SetActive(false);
            MinSlimeGenerator.gameObject.SetActive(true);
            nowWave = false;
            Debug.Log("WAVE : " + waveCount);
            waveText.text = "WAVE : " + waveCount;

            //waveCount++;

        }
        else
        {
            //tf.position = player.position + new Vector3(0.0f, 12.2f, -32.5f); //カメラを移動。

            var eneClones = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (var clone in eneClones)
            {
                Destroy(clone);
            }

            warning.gameObject.SetActive(false);
            enemyCreater.gameObject.SetActive(false);
            slimeCreater.gameObject.SetActive(true);
            MinSlimeGenerator.gameObject.SetActive(false);
            nowWave = true;
            Debug.Log("探索");
            waveText.text = "SEARCH";

            waveCount++;
        }
    }

    void Clear()
    {
        Debug.Log("CLEAR");
        SceneManager.LoadScene("Clear");
    }

    void StartCoroutine()
    {
        StartCoroutine("TextSet");
    }


    //実行内容 1秒待ってからテキスト非表示
    IEnumerator TextSet()
    {
        yield return new WaitForSeconds(1.0f);
        waveCanvas.gameObject.SetActive(false);
    }

}
