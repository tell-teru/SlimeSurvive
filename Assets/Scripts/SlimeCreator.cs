using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeCreator : BaseCreator
{
    public BaseCharacter[] slimes;
    int slimeNumber;

    //public GameObject normalSlime;

    int createNum = 30;

    public float createTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Create();
    }

    protected override void Create()
    {
        for (int i = 0; i <= createNum; i++)
        {

            float x = Random.Range(200f, 500f);
            float z = Random.Range(200f, 500f);

            slimeNumber = Random.Range(0, slimes.Length);
            transform.position = new Vector3(x, 0, z);
            Create(slimes[slimeNumber], transform);

        }
    }


}
