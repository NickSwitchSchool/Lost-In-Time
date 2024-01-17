using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] GameObject player;

    private void Update()
    {
        transform.position = new Vector3(player.transform.position.x + 1f, 0, -10);
    }
}
