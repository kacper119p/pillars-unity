using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private float range = 20.0f;
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if((transform.position - player.gameObject.transform.position).magnitude > range)
        {
            Destroy(gameObject);
        }
    }
}
