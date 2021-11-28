using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] private float speed = 5.0f;
    public Quaternion rotation {private set ; get; }  // ENCAPSULATION
    private float horizontalInput;
    private float verticalInput;
    private float yBound = 4.5f;
    private float xBound = 8.379f;
    private float cooldown = 0.25f;
    private float currentCooldown;
    private bool isOnCooldown;
    [SerializeField] GameManager gameManager;

    private void Start()
    {
        currentCooldown = 0.0f;
        isOnCooldown = false;
        rotation = Quaternion.Euler(0, 0, 0);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        GetInput();  //ABSTRACTION
        Move();
        SetRotation();

        if (isOnCooldown)
        {
            ManageCooldown();
        }

        if (Input.GetKey(KeyCode.Space) && !isOnCooldown)
        {
            Shoot();
        }
    }

    private void Move()
    {
        transform.Translate(Vector3.up * verticalInput * Time.deltaTime * speed);
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        if (transform.position.x > xBound)
        {
            transform.position = new Vector3(xBound, transform.position.y, 0);
        }
        else if (transform.position.x < -xBound)
        {
            transform.position = new Vector3(-xBound, transform.position.y, 0);
        }

        if (transform.position.y > yBound)
        {
            transform.position = new Vector3(transform.position.x, yBound, 0);
        }
        else if (transform.position.y < -yBound)
        {
            transform.position = new Vector3(transform.position.x, -yBound, 0);
        }
    }

    private void SetRotation()
    {
        if (horizontalInput == 0 && verticalInput > 0)
        {
            rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (horizontalInput < 0 && verticalInput > 0)
        {
            rotation = Quaternion.Euler(0, 0, 45);
        }
        else if (horizontalInput < 0 && verticalInput == 0)
        {
            rotation = Quaternion.Euler(0, 0, 90);
        }
        else if (horizontalInput < 0 && verticalInput < 0)
        {
            rotation = Quaternion.Euler(0, 0, 135);
        }
        else if (horizontalInput == 0 && verticalInput < 0)
        {
            rotation = Quaternion.Euler(0, 0, 180);
        }
        else if (horizontalInput > 0 && verticalInput < 0)
        {
            rotation = Quaternion.Euler(0, 0, 225);
        }
        else if (horizontalInput > 0 && verticalInput == 0)
        {
            rotation = Quaternion.Euler(0, 0, 270);
        }
        else if (horizontalInput > 0 && verticalInput > 0)
        {
            rotation = Quaternion.Euler(0, 0, 315);
        }
    }

    private void Shoot()
    {
        Instantiate(projectile, transform.position, rotation);
        isOnCooldown = true;
        currentCooldown = 0.0f;
    }

    private void ManageCooldown()
    {
        currentCooldown += Time.deltaTime;
        if(currentCooldown >= cooldown)
        {
            isOnCooldown = false;
        }
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            gameManager.EndGame();
        }
    }
}
