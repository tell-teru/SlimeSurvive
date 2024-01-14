using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator :  BaseCreator
{
    public BaseCharacter normalEnemy;

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

    protected override void Create()
    {
        playerpos = player.gameObject.transform;//中心座標
        enepos = playerpos.position + CircleHorizon(50);// 半径()の円周上に出現
        transform.position = enepos;

        Create(normalEnemy, transform);
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
