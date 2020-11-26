using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    float moveSpeed = 7.0f;
    float fTimerCount = 0f;
    float iCount = 0f;

    public Animator playerAnim;
    public GameObject PlayPlaneB;
    public GameObject PlayPlaneC;
    public GameObject PlayPlaneD;
    public GameObject PlayPlaneE;
    public GameObject Timer;

    public GameObject CoinCollected;
    public float speed;

    private int coinCount;
    private int totalCoin;

    bool timerStart = false;
    public bool trigSwitch;

    // Start is called before the first frame update
    void Start()
    {
        totalCoin = GameObject.FindGameObjectsWithTag("Coin").Length;
    }

    // Update is called once per frame
    void Update()
    {
        //movement
        if (Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            startRun();
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            playerAnim.SetBool("isRun", false);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            startRun();
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            playerAnim.SetBool("isRun", false);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(0, 270, 0);
            startRun();
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            playerAnim.SetBool("isRun", false);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
            startRun();
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            playerAnim.SetBool("isRun", false);
        }

        //lose
        if (transform.position.y < -5)
        {
            print("You lose!");
            SceneManager.LoadScene("LoseScene");
        }


        if (fTimerCount < 10 && timerStart)
        {
            fTimerCount += Time.deltaTime;
            iCount = Mathf.RoundToInt(fTimerCount);
            Timer.GetComponent<Text>().text = "Timer CountUp: " + iCount.ToString();
        }
        else if (fTimerCount >= 10 && timerStart)
        {
            fTimerCount = 0;
            iCount = 0;
            timerStart = false;
            Timer.GetComponent<Text>().text = "Time CountUp: " + iCount.ToString();
            PlayPlaneB.GetComponent<Transform>().Rotate(0, 90, 0);
        }
    }

    void startRun()
    {
        playerAnim.SetBool("isRun", true);
        playerAnim.SetFloat("startRun", 0.26f);
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("TagCone"))
        {
            if (coinCount == totalCoin && timerStart == false)
            {
                timerStart = true;

                Debug.Log("Condition have been made.");
                PlayPlaneB.transform.Rotate(0f, 90f, 0f);
            }
        }

        if (other.gameObject.tag == "Coin")
        {
            coinCount++;
            CoinCollected.GetComponent<Text>().text = "Coin Collected: " + coinCount;
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Switch"))
        {
            Debug.Log("Collided with Switch.");
            trigSwitch = true;
        }
    }
}
