using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeCreater : MonoBehaviour
{
    public GameObject[] slimes;
    int slimeNumber;

    //public GameObject normalSlime;

    int createNum = 30;

    public float createTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Create();
    }

    // Update is called once per frame
    void Update()
    {
        createTime += Time.deltaTime;

        if (createTime >= 10f)
        {
            Create();
            createTime = 0.0f;
        }
    }

    void Create()
    {
        for (int i = 0; i <= createNum; i++)
        {

            float x = Random.Range(200f, 500f);
            float z = Random.Range(200f, 500f);

            slimeNumber = Random.Range(0, slimes.Length);
            transform.position = new Vector3(x, 0, z);
            Instantiate(slimes[slimeNumber], transform.position, transform.rotation);

        }
    }
}
