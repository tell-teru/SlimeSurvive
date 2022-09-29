using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{

    private GameObject mainCamera;      //メインカメラ格納用
    private GameObject subCamera;       //サブカメラ格納用

    WaveManager waveManager;

    //Camera
    //public Transform tf; //Main CameraのTransform
    public GameObject player;

    void Start()
    {
        waveManager = player.gameObject.GetComponent<WaveManager>();

        //メインカメラとサブカメラをそれぞれ取得
        mainCamera = GameObject.Find("MainCamera");
        subCamera = GameObject.Find("SubCamera");

        //サブカメラを非アクティブにする
        mainCamera.SetActive(false);
    }

    void Update()
    {
        //スペースキーが押されている間、サブカメラをアクティブにする
        if (waveManager.nowWave == true)
        {
            //サブカメラをアクティブに設定
            mainCamera.SetActive(false);
            subCamera.SetActive(true);
        }
        else if(waveManager.nowWave == false)
        {
            //メインカメラをアクティブに設定
            mainCamera.SetActive(true);
            subCamera.SetActive(false);
        }
    }
}
