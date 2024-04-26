using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueMinion : MonoBehaviour
{
    public float moveSpeed = 0.5f;
    [SerializeField] private int hp;

    private void Start()
    {
        hp = 1;
    }

    private void Update()
    {
        // Move the AI to the left
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Red"))
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
