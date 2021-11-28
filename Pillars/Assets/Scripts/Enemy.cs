using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour // INHERITANCE
{
    protected float speed = 3.0f;
    protected GameObject player;

    private void Awake()
    {
        player = GameObject.Find("Player");
    }
    void Update()
    {
        Move();
    }

    protected abstract void Move();

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerProjectile"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
