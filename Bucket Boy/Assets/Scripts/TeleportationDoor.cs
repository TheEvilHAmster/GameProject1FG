using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportationDoor : MonoBehaviour
{
    [SerializeField] private GameObject telepotyEndpoint, player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(Teleport());
    }

    IEnumerator Teleport()
    {
        yield return new WaitForSeconds(0);
        player.transform.position =
            new Vector2(telepotyEndpoint.transform.position.x, telepotyEndpoint.transform.position.y);
    }
}
