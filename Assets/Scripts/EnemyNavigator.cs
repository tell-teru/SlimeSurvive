using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavigator : BaseCharacter
{
    public Transform target;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");//Playerタグのオジェクトを探して
        target = player.transform;// player をtargetにした
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        // target に向かって追いかける処理
        agent.SetDestination(target.transform.position);
    }

    public override void Setup()
    {
        base.Setup();
        Debug.Log("エネミーがセットアップされた");
    }
}
