using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(addBatteryLife(other));
    }

    IEnumerator addBatteryLife(Collider2D other)
    {
        yield return new WaitForSeconds(0);
        
    }
}
