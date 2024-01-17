using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBumpCheckScript : MonoBehaviour
{
    [SerializeField] GameObject player;


    private void FixedUpdate()
    {
        if (player.GetComponent<PlayerScript>().GetFloored())
        {
            player.GetComponent<PlayerScript>().WallBumping(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.gameObject.tag != "Player" && !player.GetComponent<PlayerScript>().GetFloored())
        {
            player.GetComponent<PlayerScript>().WallBumping(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.gameObject.tag != "Player")
        {
            player.GetComponent<PlayerScript>().WallBumping(false);
        }
    }
}