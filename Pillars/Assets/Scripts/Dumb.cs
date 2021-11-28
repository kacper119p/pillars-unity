using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dumb : Enemy // INHERITANCE
{
    // Start is called before the first frame update
    void Start()
    {
        SetDirection();
    }

    protected override void Move() // POLYMORPHISM
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }

    private void SetDirection()
    {
        transform.up = player.gameObject.transform.position - transform.position;
    }
}
