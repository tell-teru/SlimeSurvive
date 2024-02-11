using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SlimeCreator : MonoBehaviour
{
    [SerializeField] private GameObject[] slimes;
    private int slimeNumber;

    private int createNum = 30;

    private float createTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Create();
    }

    // Update is called once per frame
    void Update()
    {
        createTime += Time.deltaTime;

        if (createTime >= 7f)
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
            GameObject newSlime = Instantiate(slimes[slimeNumber], transform.position, transform.rotation);

            newSlime.transform.DOPunchScale(Vector3.one * 1.5f, 1f)
                .SetEase(Ease.OutQuad);
        }
    }
}
