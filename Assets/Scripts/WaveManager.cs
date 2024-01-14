using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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


    // Start is called before the first frame update
    void Start()
    {
        WaveSwitch();

        //waveCanvas.gameObject.SetActive(false);


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
            //tf.position = player.position + new Vector3(0.0f, 1.75f, -2.63f); //カメラを移動。

            //文字うきだし
            waveCanvas.gameObject.SetActive(true);
            StartCoroutine("TextSet");//コルーチンを実行


            //クローン一気に消す
            //GameObject slime = GameObject.FindGameObjectWithTag("Slime");//Playerタグのオジェクトを探して
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

            //warning.gameObject.SetActive(true);
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


    //実行内容 1秒待ってからテキスト非表示
    IEnumerator TextSet()
    {
        yield return new WaitForSeconds(1.0f);
        waveCanvas.gameObject.SetActive(false);
    }

}
