using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agressive : Enemy
{

    protected override void Move() // POLYMORPHISM
    {
        transform.up = player.gameObject.transform.position - transform.position;
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}
