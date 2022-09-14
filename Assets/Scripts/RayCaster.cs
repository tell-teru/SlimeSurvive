using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCaster : MonoBehaviour
{
    public Camera playerCamera;

    // Start is called before the first frame update
    void Start()
    {
        // 中央にカーソルをロック
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shot();
        }
    }


    void Shot()
    {
        int distance = 10;
        Vector3 center = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Ray ray = playerCamera.ScreenPointToRay(center);
        RaycastHit hitInfo;

        if(Physics.Raycast(ray, out hitInfo, distance))
        {
            //Debug.DrawLine(ray.origin, hitInfo.point, Color.red);
            Debug.Log("名前は　" + hitInfo.collider.name);
            Debug.Log("距離は　" + hitInfo.distance);
            Debug.Log("場所は　" + hitInfo.point);


            if(hitInfo.collider.tag == "Enemy")
            {
                Destroy(hitInfo.collider.gameObject);
            }
        }
    }
}
