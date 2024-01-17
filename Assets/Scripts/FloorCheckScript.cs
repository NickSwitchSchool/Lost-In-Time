using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCheckScript : MonoBehaviour
{
    [SerializeField] GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.gameObject.tag != "Player")
        {
            player.GetComponent<PlayerScript>().Floored(true);
        }
    }
}
