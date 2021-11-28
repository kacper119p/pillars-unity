using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArrow : MonoBehaviour
{
    [SerializeField] private GameObject player;
    void LateUpdate()
    {
        transform.rotation = player.GetComponent<PlayerController>().rotation * Quaternion.Euler(0, 0, 45);
    }
}
