using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreater : MonoBehaviour
{
    public GameObject normalEnemy;

    float norEneTimer = 0f;
    float norEneInterval =　0.5f;

    PlayerController playerController;
    public GameObject player;

    private Transform playerpos;
    private Vector3 enepos;

    // Start is called before the first frame update
    void Start()
    {
        playerController = player.gameObject.GetComponent<PlayerController>();
        //playerpos = player.gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        norEneTimer += Time.deltaTime;
        playerpos = player.gameObject.transform;//中心座標


        enepos = playerpos.position + CircleHorizon(50);// 半径()の円周上に出現

        if (norEneTimer >= norEneInterval)
        {
            transform.position = enepos;

            Instantiate(normalEnemy, transform.position, transform.rotation);

            
            norEneTimer = 0;
        }

    }


    private Vector3 CircleHorizon(float radius)
    {
        var angle = Random.Range(0, 360);
        var rad = angle * Mathf.Deg2Rad;
        var px = Mathf.Cos(rad) * radius;
        var pz = Mathf.Sin(rad) * radius;
        return new Vector3(px, 0, pz);
    }
}
