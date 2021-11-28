using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour // INHERITANCE
{
    protected float speed = 3.0f;
    protected GameObject player;
    protected GameManager gameManager;

    private void Awake()
    {
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
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
            gameManager.score++;
        }
    }
}
