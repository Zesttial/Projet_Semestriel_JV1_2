using System;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class detection_range : MonoBehaviour
{
    public GameObject player;
    public GameObject range;
    public float speed;
    private void OnTriggerEnter2D(Rigidbody2D other)
    {
        if(other.tag == "Player")
        {
            Vector2 Normalize = player.transform.position - transform.position;

            transform.position = Vector2.MoveTowards (this.transform.position, player.transform.position, speed);
        }
    }
}
