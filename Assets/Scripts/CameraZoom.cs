using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{

    WaveManager waveManager;
    public GameObject parent;

    //Camera
    //public Transform tf; //Main CameraのTransform
    public Transform player;

    void Start()
    {
        //Camera
        //tf = tf.gameObject.GetComponent<Transform>(); //Main CameraのTransformを取得する。
        player = this.GetComponent<Transform>(); //Main CameraのTransformを取得する。

        waveManager = parent.gameObject.GetComponent<WaveManager>();
    }

    void Update()
    {
        if(waveManager.nowWave == true)
        {
            player.position = new Vector3(300.0f, 1f, 300f) +  new Vector3(0.0f, 1.75f, -2.63f); //カメラを移動。
        }

        else if (waveManager.nowWave == false)
        {
            player.position = new Vector3(300.0f, 1f, 300f) + new Vector3(0.0f, 12.2f, -32.5f); //カメラを移動。
        }


    }
}
