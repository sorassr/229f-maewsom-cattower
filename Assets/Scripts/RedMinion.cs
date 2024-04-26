using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedMinion : MonoBehaviour
{
    public float moveSpeed = 5f;
    [SerializeField] private int hp;

    private void Start()
    {
        hp = 1;
    }

    private void Update()
    {
        // Move the AI to the left
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Blue"))
        {
            hp--;
            Debug.Log(hp);
            if (hp == 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
