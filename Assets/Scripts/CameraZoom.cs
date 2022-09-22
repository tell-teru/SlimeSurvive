using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public Transform tf; //Main CameraのTransform
    Camera cam; //Main CameraのCamera

    public Transform player;

    void Start()
    {
        tf = this.GetComponent<Transform>(); //Main CameraのTransformを取得する。
        cam = this.gameObject.GetComponent<Camera>(); //Main CameraのCameraを取得する。

        player = player.GetComponent<Transform>(); //Main CameraのTransformを取得する。
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.I)) //Iキーが押されていれば
        {
            cam.orthographicSize = cam.orthographicSize - 1.0f; //ズームイン。

            //tf.position = tf.position + new Vector3(0.0f, 1.0f, 0.0f); //カメラを上へ移動。
            tf.position = player.position + new Vector3(0.0f, 12.2f, -32.5f); //カメラを上へ移動。

        }
        else if (Input.GetKey(KeyCode.O)) //Oキーが押されていれば
        {
            cam.orthographicSize = cam.orthographicSize + 1.0f; //ズームアウト。

            tf.position = player.position + new Vector3(0.0f, 1.75f, -2.63f); //カメラを上へ移動。

        }
        //if (Input.GetKey(KeyCode.UpArrow)) //上キーが押されていれば
        //{
        //    tf.position = tf.position + new Vector3(0.0f, 1.0f, 0.0f); //カメラを上へ移動。
        //}
        //else if (Input.GetKey(KeyCode.DownArrow)) //下キーが押されていれば
        //{
        //    tf.position = tf.position + new Vector3(0.0f, -1.0f, 0.0f); //カメラを下へ移動。
        //}
        //if (Input.GetKey(KeyCode.LeftArrow)) //左キーが押されていれば
        //{
        //    tf.position = tf.position + new Vector3(-1.0f, 0.0f, 0.0f); //カメラを左へ移動。
        //}
        //else if (Input.GetKey(KeyCode.RightArrow)) //右キーが押されていれば
        //{
        //    tf.position = tf.position + new Vector3(1.0f, 0.0f, 0.0f); //カメラを右へ移動。
        //}
    }
}
