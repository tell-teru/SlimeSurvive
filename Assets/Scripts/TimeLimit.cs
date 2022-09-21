using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeLimit : MonoBehaviour
{
    public Image timeObj;
    public bool roop;
    public float countTime = 10.0f;

    public float time;

    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(timerObj, new Vector3(-1.0f, 0.0f, 0.0f), Quaternion.identity);
        timeObj = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if(time <= countTime)
        {
            timeObj.color = Color.cyan;
            timeObj.fillAmount -= (1.0f / countTime) * Time.deltaTime;

            if (timeObj.fillAmount == 0.0f)
            {
                timeObj.fillAmount = 1.0f;
            }

        }

        else if (time > countTime)
        {
            
            timeObj.color = Color.red;
            timeObj.fillAmount -= (1.0f / countTime) * Time.deltaTime;



            if (timeObj.fillAmount == 0.0f)
            {
                timeObj.fillAmount = 1.0f;
            }

        }

        else if (time >= countTime * 2)
        {
            time = 0.0f;
        }

    }
}
