using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    private float horizontalInput;
    private float verticalInput;
    private float yBound = 4.5f;
    private float xBound = 8.379f;

    void Update()
    {
        GetInput();  //ABSTRACTION
        Move();

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void Move()
    {
        transform.Translate(Vector3.up * verticalInput * Time.deltaTime * speed);
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        if(transform.position.x > xBound)
        {
            transform.position = new Vector3(xBound, transform.position.y, 0);
        }
        else if(transform.position.x < -xBound)
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

    private void Shoot()
    {

    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }
}
