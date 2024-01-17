using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTrigger : MonoBehaviour
{
    [SerializeField] int level;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            LevelManager.EndAndStartNewLevel(level);
            other.GetComponent<PlayerScript>().SetCheckpoint(other.transform.position);
        }
    }
}
