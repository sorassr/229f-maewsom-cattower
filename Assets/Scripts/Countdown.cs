using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Countdown : MonoBehaviour
{
    public float countdownTime = 3f;
    public TextMeshProUGUI countdownDisplay;
    public KeyCode player1Key = KeyCode.A;
    public KeyCode player2Key = KeyCode.L;

    private bool countdownFinished = false;
    private bool player1Pressed = false;
    private bool player2Pressed = false;
    
    private ProjectileSpawnMinion SpawnMinion;
    
    private Rigidbody2D PrefabtoSpawn;
    [SerializeField] private Rigidbody2D norCatPrefabBlue;
    [SerializeField] private Rigidbody2D norCatPrefabRed;
    [SerializeField] private Rigidbody2D tankCatPrefabBlue;
    [SerializeField] private Rigidbody2D tankCatPrefabRed;
    
    [SerializeField] private int a;

    [SerializeField] private Image norCat;
    [SerializeField] private Image tankCat;
    
    private void Start()
    {
        SpawnMinion = GameObject.FindWithTag("SpawnMinion").GetComponent<ProjectileSpawnMinion>();
        StartCoroutine(CountdownTime());
        RandomForSpawn();
    }

    private void Update()
    {
        if (countdownFinished)
        {
            if (Input.GetKeyDown(player1Key) && !player1Pressed)
            {
                if (a >= 0 && a <= 3)
                {
                    PrefabtoSpawn = norCatPrefabBlue;
                }
                else if (a == 4)
                {
                    PrefabtoSpawn = tankCatPrefabBlue;
                }
                Debug.Log("Player 1 Wins!");
                SpawnMinion.SpawnBlueMinion(PrefabtoSpawn);
                ResetGame();
            }
            else if (Input.GetKeyDown(player2Key) && !player2Pressed)
            {
                if (a >= 0 && a <= 3)
                {
                    PrefabtoSpawn = norCatPrefabRed;
                }
                else if (a == 4)
                {
                    PrefabtoSpawn = tankCatPrefabRed;
                }
                Debug.Log("Player 2 Wins!");
                SpawnMinion.SpawnRedMinion(PrefabtoSpawn);
                ResetGame();
            }
        }
    }

    IEnumerator CountdownTime()
    {
        while (countdownTime > 0)
        {
            UpdateCountdownDisplay();
            yield return new WaitForSeconds(1f);
            countdownTime--;
        }

        // Countdown finished
        countdownFinished = true;
        countdownDisplay.text = "GO!";
        yield return new WaitForSeconds(1f);
    }

    void UpdateCountdownDisplay()
    {
        countdownDisplay.text = countdownTime.ToString();
    }

    void ResetGame()
    {
        RandomForSpawn();
        countdownTime = 3f;
        countdownDisplay.text = countdownTime.ToString();
        player1Pressed = false;
        countdownFinished = false;
        player2Pressed = false;
        StartCoroutine(CountdownTime());
    }
    
    void RandomForSpawn()
    {
        System.Random random = new System.Random();
        a = random.Next(0, 5);
        if (a >= 0 && a <= 3)
        {
            norCat.gameObject.SetActive(true);
            tankCat.gameObject.SetActive(false);
        }
        else if (a == 4)
        {
            norCat.gameObject.SetActive(false);
            tankCat.gameObject.SetActive(true);
        }
    }
}
