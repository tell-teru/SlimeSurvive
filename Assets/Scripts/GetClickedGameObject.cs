using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetClickedGameObject : MonoBehaviour
{

    GameObject clickedGameObject;

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {

            clickedGameObject = null;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            if (Physics.Raycast(ray, out hit))
            {
                clickedGameObject = hit.collider.gameObject;

                if (clickedGameObject.tag == "Enemy")
                {
                    Destroy(clickedGameObject);
                }
            }

            Debug.Log(clickedGameObject);
        }
    }
}