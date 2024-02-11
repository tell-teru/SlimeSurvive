using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{

    private Vector3 slimeScale;  //①仮の変数宣言
    public Vector3 SlimeScale
    {
        get { return slimeScale; }
        set { slimeScale = value; }
    }

    private Vector3 v0 = new Vector3(0.0f, 0.0f, 0.0f);
    public Vector3 V0
    {
        get { return v0; }
        set { v0 = value; }
    }

    private Vector3 v3 = new Vector3(0.3f, 0.3f, 0.3f);
    private Vector3 v4 = new Vector3(0.4f, 0.4f, 0.4f);

    [SerializeField] private GameObject gameOverText;
    private bool gameOver;

    private int playerHp = 0;
    public int PlayerHp
    {
        get { return playerHp; }
    }

    [SerializeField] private GameObject warning;

    private WaveManager isWave;

    [SerializeField] Text sizeText;
    [SerializeField] Text armarText;
    public Text SizeText
    {
        get { return sizeText; }
        set { sizeText = value; }
    }

    public Text ArmarText
    {
        get { return armarText; }
        set { armarText = value; }
    }

    [SerializeField] private AudioClip sound1;
    [SerializeField] private AudioClip sound2;
    [SerializeField] private AudioClip sound3;
    private AudioSource audioSource;

    [SerializeField] private Text addSizeText;

    [SerializeField] private GameObject waterPrefab;
    [SerializeField] private GameObject explosionPrefab;

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
        //Debug.Log(" Hit ");
        if(other.gameObject.tag == "Slime")
        {
            slimeScale += new Vector3(0.1f, 0.1f, 0.1f);//②変数keroのx座標を1増やして代入

            gameObject.transform.localScale = slimeScale; //③大きさに変数keroを代入

            gameObject.transform.position += new Vector3(0, 0.1f, 0);

            Debug.Log("+1");
            ShowAddSizeText();
            addSizeText.text = "+1";

            Instantiate(waterPrefab, transform.position, Quaternion.identity);

            Destroy(other.gameObject);
            audioSource.PlayOneShot(sound1);

        }

        if (other.gameObject.tag == "Armar")
        {

            slimeScale += new Vector3(0.3f, 0.3f, 0.3f);//②変数keroのx座標を1増やして代入

            gameObject.transform.localScale = slimeScale; //③大きさに変数keroを代入

            gameObject.transform.position += new Vector3(0, 0.3f, 0);

            ShowAddSizeText();
            addSizeText.text = "+3";

            Instantiate(waterPrefab, transform.position, Quaternion.identity);

            Destroy(other.gameObject);
            audioSource.PlayOneShot(sound1);

        }

        if (other.gameObject.tag == "Helmet")
        {
            playerHp += 3;

            Debug.Log("HP+3");

            Instantiate(waterPrefab, transform.position, Quaternion.identity);

            Destroy(other.gameObject);
            audioSource.PlayOneShot(sound1);

        }

        if (other.gameObject.tag == "King")
        {
            playerHp += 5;

            slimeScale += new Vector3(1.0f, 1.0f, 1.0f);//②変数keroのx座標を1増やして代入

            gameObject.transform.localScale = slimeScale; //③大きさに変数keroを代入

            gameObject.transform.position += new Vector3(0, 1.0f, 0);

            Debug.Log("+10");
            ShowAddSizeText();
            addSizeText.text = "+10";

            Instantiate(waterPrefab, transform.position, Quaternion.identity);

            Destroy(other.gameObject);
            audioSource.PlayOneShot(sound1);

        }

        if (other.gameObject.tag == "Enemy")
        {

            if(playerHp == 0)
            {
                slimeScale -= new Vector3(0.1f, 0.1f, 0.1f);//②変数keroのx座標を1増やして代入

                gameObject.transform.localScale = slimeScale; //③大きさに変数keroを代入

                gameObject.transform.position -= new Vector3(0, 0.1f, 0);

                Debug.Log("-1");
                ShowAddSizeText();
                addSizeText.text = "-1";

                Instantiate(explosionPrefab, transform.position, Quaternion.identity);

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

    void ShowAddSizeText()
    {
        addSizeText.transform.localScale = Vector3.zero;
        addSizeText.transform.DOScale(1f, 0.5f)
            .SetEase(Ease.OutBounce)
            .OnComplete(StartCoroutine);
    }

    void StartCoroutine()
    {
        addSizeText.transform.DOScale(Vector3.zero, 0.5f)
            .SetEase(Ease.OutBounce);
        StartCoroutine("TextSet");
    }

    //実行内容 1秒待ってからテキスト非表示
    IEnumerator TextSet()
    {
        yield return new WaitForSeconds(0.3f);
        addSizeText.text = "";
    }
}
