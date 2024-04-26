using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankCatBlue : MonoBehaviour
{
    public float moveSpeed = 0.5f;
    [SerializeField] private int hp;

    private void Start()
    {
        hp = 2;
    }

    private void Update()
    {
        
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

    /*private void OnCollisionStay2D(Collision2D collisionInfo)
    {
        if (collisionInfo.gameObject.CompareTag("Red"))
        {
            hp--;
            Debug.Log(hp);
            if (hp == 0)
            {
                Destroy(this.gameObject);
            }
        }
    }*/
}
