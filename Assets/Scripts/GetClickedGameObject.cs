using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetClickedGameObject : MonoBehaviour
{

    GameObject clickedGameObject;

    private float timer = 0.5f;

    private float power;
    public Rigidbody rb;
    public GameObject target;

    PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = this.gameObject.GetComponent<PlayerController>();

        power = 30;
        target = GameObject.FindGameObjectWithTag("Enemy");
    }

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
                    Destroy(clickedGameObject, timer);
                    //Destroy(clickedGameObject);

                    //HitTarget();


                    playerController.slimeScale -= new Vector3(0.1f, 0.1f, 0.1f);//②変数keroのx座標を1増やして代入

                    gameObject.transform.localScale = playerController.slimeScale; //③大きさに変数keroを代入

                    gameObject.transform.position -= new Vector3(0, 0.1f, 0);

                    Debug.Log("-1");

                    if (playerController.slimeScale == playerController.v0)
                    {
                        playerController.GameOver();
                    }

                }
            }

            playerController.sizeText.text = "S I Z E : " + Mathf.Ceil(playerController.slimeScale.x * 10) ;
            playerController.armarText.text = "Armar : " + playerController.playerHp;

            Debug.Log(clickedGameObject);
        }
    }



    public void HitTarget()
    {
        transform.LookAt(target.transform);
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward.normalized * power;
    }
}