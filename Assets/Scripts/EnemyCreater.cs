using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreater : MonoBehaviour
{
    public GameObject normalEnemy;

    float norEneTimer = 0f;
    float norEneInterval = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        norEneTimer += Time.deltaTime;


        if (norEneTimer >= norEneInterval)
        {
            transform.position = new Vector3(Random.Range(200.0f, 250.0f), 0, Random.Range(200.0f, 400.0f));
            Instantiate(normalEnemy, transform.position, transform.rotation);

            transform.position = new Vector3(Random.Range(350.0f, 400.0f), 0, Random.Range(200.0f, 400.0f));
            Instantiate(normalEnemy, transform.position, transform.rotation);

            transform.position = new Vector3(Random.Range(200.0f, 400.0f), 0, Random.Range(200.0f, 250.0f));
            Instantiate(normalEnemy, transform.position, transform.rotation);

            transform.position = new Vector3(Random.Range(200.0f, 400.0f), 0, Random.Range(350.0f, 400.0f));
            Instantiate(normalEnemy, transform.position, transform.rotation);

           
            norEneTimer = 0;
        }

    }
}
