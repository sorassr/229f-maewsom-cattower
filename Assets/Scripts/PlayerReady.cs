using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerReady : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI player1PressA;
    [SerializeField] private TextMeshProUGUI player2PressL;
    [SerializeField] private TextMeshProUGUI start;
    private bool isPlayer1Ready;
    private bool isPlayer2Ready;
    public float countdownTime = 2f;
    private bool oneTimeRun;

    [SerializeField] private Image background;

    [SerializeField] private GameObject countdown;
    // Start is called before the first frame update
    void Start()
    {
        countdown.SetActive(false);
        isPlayer1Ready = false;
        isPlayer2Ready = false;
        start.gameObject.SetActive(false);
        oneTimeRun = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            player1PressA.text = "Player 1 ready!!";
            isPlayer1Ready = true;
        }
        
        if (Input.GetKeyDown(KeyCode.L))
        {
            player2PressL.text = "Player 2 ready!!";
            isPlayer2Ready = true;
        }

        if (!oneTimeRun)
        {
            if (isPlayer1Ready & isPlayer2Ready)
            {
                background.gameObject.SetActive(false);
                player1PressA.gameObject.SetActive(false);
                player2PressL.gameObject.SetActive(false);
                start.gameObject.SetActive(true);
                StartCoroutine(StartCountdown());
                oneTimeRun = true;
            }
        }
       
    }
    IEnumerator StartCountdown()
    {
        float currentTime = countdownTime;

        while (currentTime > 0)
        {
            Debug.Log("Time remaining: " + currentTime.ToString("0.00"));
            yield return new WaitForSeconds(1f);
            currentTime--;
        }
        countdown.SetActive(true);
        start.gameObject.SetActive(false);
        Debug.Log("Countdown complete!");
    }
}
