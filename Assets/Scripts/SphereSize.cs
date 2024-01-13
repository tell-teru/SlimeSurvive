using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereSize : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    private GameObject ballObj;
    private Vector3 mousePosition;
    private int count;

    void Start()
    {
        count = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            mousePosition = Input.mousePosition;
            mousePosition.z = 10.0f;
            GameObject obj = Instantiate(prefab, Camera.main.ScreenToWorldPoint(mousePosition), Quaternion.identity);
            count++;
            if (count == 1)
            {
                obj.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            }
            if (count == 2)
            {
                obj.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            }
            if (count == 3)
            {
                obj.transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);
                count = 0;
            }
        }
    }
}