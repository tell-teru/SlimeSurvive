using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public Vector3 slimeScale;  //①仮の変数宣言
    public Vector3 v0 = new Vector3(0.0f, 0.0f, 0.0f);
    Vector3 v3 = new Vector3(0.3f, 0.3f, 0.3f);
    Vector3 v4 = new Vector3(0.4f, 0.4f, 0.4f);

    public GameObject gameOverText;
    public bool gameOver;

    public int playerHp = 0;

    public GameObject warning;

    WaveManager isWave;

    public Text sizeText;
    public Text armarText;


    public AudioClip sound1;
    public AudioClip sound2;
    public AudioClip sound3;
    AudioSource audioSource;

    public GameObject addCanvas;
    public Text addText;


    [SerializeField] GameObject waterPrefab;
    [SerializeField] GameObject explosionPrefab;

    // Start is called before the first frame update
    void Start()
    {
        slimeScale = gameObject.transform.localScale; //◆現在の大きさを代入
        sizeText.text = "S I Z E : " + 5;
        armarText.text = "Armar : " + 0;

        gameOverText.gameObject.SetActive(false);
        gameOver = false;

        warning.gameObject.SetActive(false);

        isWave = this.GetComponent<WaveManager>();

        //Componentを取得
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(slimeScale == v0)
        {
            GameOver();
        }


        ////Warning
        if (Vector3.SqrMagnitude(slimeScale - v3) < 0.0001)
        {
            warning.gameObject.SetActive(true);
        }

        if (Vector3.SqrMagnitude(slimeScale - v4) < 0.0001)
        {
            warning.gameObject.SetActive(false);
        }


        sizeText.text = "S I Z E : " + Mathf.Ceil(slimeScale.x * 10);
        armarText.text = "Armar : " + playerHp;


        
    }

    //public void OnTriggerEnter(Collider other)
    public void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.TryGetComponent<BaseCharacter>(out BaseCharacter baseCharacter))
        { 
            return;
        }

        SlimeType slimeType = baseCharacter.SlimeType;

        //Debug.Log(" Hit ");
        if (slimeType == SlimeType.Hp)
        {
            slimeScale += new Vector3(0.1f, 0.1f, 0.1f);//②変数keroのx座標を1増やして代入

            gameObject.transform.localScale = slimeScale; //③大きさに変数keroを代入

            gameObject.transform.position += new Vector3(0, 0.1f, 0);

            Debug.Log("+1");
            addText.text = "+1";
            StartCoroutine("TextSet");//コルーチンを実行


            Instantiate(waterPrefab, transform.position, Quaternion.identity);
            //Destroy(waterPrefab.gameObject);

            Destroy(other.gameObject);
            audioSource.PlayOneShot(sound1);

        }

        if (slimeType == SlimeType.Armer)
        {

            slimeScale += new Vector3(0.3f, 0.3f, 0.3f);//②変数keroのx座標を1増やして代入

            gameObject.transform.localScale = slimeScale; //③大きさに変数keroを代入

            gameObject.transform.position += new Vector3(0, 0.3f, 0);

            Debug.Log("+3");
            addText.text = "+3";
            StartCoroutine("TextSet");//コルーチンを実行

            Instantiate(waterPrefab, transform.position, Quaternion.identity);
            //Destroy(waterPrefab.gameObject);

            Destroy(other.gameObject);
            audioSource.PlayOneShot(sound1);

        }

        if (slimeType == SlimeType.Helmet)
        {
            playerHp += 3;

            Debug.Log("HP+3");

            Instantiate(waterPrefab, transform.position, Quaternion.identity);
            //Destroy(waterPrefab.gameObject);

            Destroy(other.gameObject);
            audioSource.PlayOneShot(sound1);

        }

        if (slimeType == SlimeType.King)
        {
            playerHp += 5;

            slimeScale += new Vector3(1.0f, 1.0f, 1.0f);//②変数keroのx座標を1増やして代入

            gameObject.transform.localScale = slimeScale; //③大きさに変数keroを代入

            gameObject.transform.position += new Vector3(0, 1.0f, 0);

            Debug.Log("+10");
            addText.text = "+10";
            StartCoroutine("TextSet");//コルーチンを実行

            Instantiate(waterPrefab, transform.position, Quaternion.identity);
            //Destroy(waterPrefab.gameObject);

            Destroy(other.gameObject);
            audioSource.PlayOneShot(sound1);

        }

        if (slimeType == SlimeType.Enemy)
        {

            if(playerHp == 0)
            {
                slimeScale -= new Vector3(0.1f, 0.1f, 0.1f);//②変数keroのx座標を1増やして代入

                gameObject.transform.localScale = slimeScale; //③大きさに変数keroを代入

                gameObject.transform.position -= new Vector3(0, 0.1f, 0);

                Debug.Log("-1");
                addText.text = "-1";
                StartCoroutine("TextSet");//コルーチンを実行

                Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                //Destroy(explosionPrefab.gameObject);

                audioSource.PlayOneShot(sound2);
            }
            else if(playerHp != 0)
            {
                playerHp -= 1;
                Debug.Log("HP : " + playerHp);
                audioSource.PlayOneShot(sound3);
            }
            

        }
    }



    public void GameOver()
    {
        Debug.Log("GameOver");

        gameOverText.gameObject.SetActive(true);
        gameOver = true;

        SceneManager.LoadScene("GameOver");
    }

    //実行内容 1秒待ってからテキスト非表示
    IEnumerator TextSet()
    {
        yield return new WaitForSeconds(0.3f);
        addText.text = "";
    }
}
