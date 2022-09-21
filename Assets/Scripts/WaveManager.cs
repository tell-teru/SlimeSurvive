using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{
    public float waveTimer = 0;

    public GameObject slimeCreater;
    public GameObject enemyCreater;

    public bool nowWave = false;

    public int waveCount = 0;


    public Text waveText;
    public GameObject waveCanvas;


    // Start is called before the first frame update
    void Start()
    {
        WaveSwitch();

        waveCanvas.gameObject.SetActive(false);
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
            waveCanvas.gameObject.SetActive(true);
            StartCoroutine("TextSet");//コルーチンを実行

            //GameObject slime = GameObject.FindGameObjectWithTag("Slime");//Playerタグのオジェクトを探して
            var slimClones = GameObject.FindGameObjectsWithTag("Slime");
            foreach(var clone in slimClones)
            {
                Destroy(clone);
            }


            enemyCreater.gameObject.SetActive(true);
            slimeCreater.gameObject.SetActive(false);
            nowWave = false;
            Debug.Log("WAVE : " + waveCount);
            waveText.text = "WAVE : " + waveCount;

            //waveCount++;

        }
        else
        {
            var eneClones = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (var clone in eneClones)
            {
                Destroy(clone);
            }

            enemyCreater.gameObject.SetActive(false);
            slimeCreater.gameObject.SetActive(true);
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
