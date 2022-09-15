using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveManager : MonoBehaviour
{
    public float waveTimer = 0;

    public GameObject slimeCreater;
    public GameObject enemyCreater;

    public bool nowWave = false;

    public int waveCount = 0;


    // Start is called before the first frame update
    void Start()
    {
        WaveSwitch();
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

        if(waveCount == 2)
        {
            Clear();
        }
    }

    void WaveSwitch()
    {
        if (nowWave == true)
        {

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

            waveCount++;
        }
    }

    void Clear()
    {
        Debug.Log("CLEAR");
        SceneManager.LoadScene("Clear");
    }

}
