using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderSize : MonoBehaviour
{
    SphereCollider col;
    private float size;
    private bool flag;

    void Start()
    {
        col = GetComponent<SphereCollider>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && !flag)
        {
            flag = true;
            StartCoroutine("ZoomUp");
        }

        if (Input.GetKeyDown(KeyCode.Return) && flag)
        {
            flag = false;
            StartCoroutine("ZoomOut");
        }
    }

    IEnumerator ZoomUp()
    {
        for (float i = 0; i < 1; i += 0.1f)
        {
            col.radius += 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator ZoomOut()
    {
        for (float k = 0; k < 1; k += 0.1f)
        {
            col.radius -= 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
    }
}