using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HPManager : MonoBehaviour
{
    public Image healthBar;
    public float blueHealthAmount = 100f;
    public float redHealthAmount = 100f;
    public MyEnum teamKing;

    public enum MyEnum
    {
        Blue,
        Red
    };

    public void TakeDamage(float damage)
    {
        if (teamKing == MyEnum.Blue)
        {
            blueHealthAmount -= damage;
            healthBar.fillAmount = blueHealthAmount / 100f;
            if (blueHealthAmount <= 0)
            {
                Debug.Log("Red Team Wins!");
                SceneManager.LoadScene("Winning2");
                // You can add more logic here for game over or resetting the scene
            }
        }
        else if (teamKing == MyEnum.Red)
        {
            redHealthAmount -= damage;
            healthBar.fillAmount = redHealthAmount / 100f;
            if (redHealthAmount <= 0)
            {
                Debug.Log("Blue Team Wins!");
                SceneManager.LoadScene("Winning1");
                // You can add more logic here for game over or resetting the scene
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (teamKing == MyEnum.Red && col.gameObject.CompareTag("Blue"))
        {
            TakeDamage(20);
            Destroy(col.gameObject);
        }
        else if (teamKing == MyEnum.Blue && col.gameObject.CompareTag("Red"))
        {
            TakeDamage(20);
            Destroy(col.gameObject);
        }
    }
}
