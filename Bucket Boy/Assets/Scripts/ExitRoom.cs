using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class ExitRoom : MonoBehaviour
{
    [SerializeField] private Light2D light2D;

    private void OnTriggerExit2D(Collider2D other)
    {
        StartCoroutine(OnExitRoom());
    }

    IEnumerator OnExitRoom()
    {
        yield return new WaitForSeconds(0);
        TurnOffLights();
    }

    void TurnOffLights()
    {
        if (light2D == null)
            return;

        light2D.gameObject.SetActive(false);

    }
}
