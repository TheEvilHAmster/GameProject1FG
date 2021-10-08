using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class EnterRoom : MonoBehaviour
{
    
    [SerializeField] private Light2D light2D;

    private void OnTriggerExit2D(Collider2D other)
    {
        StartCoroutine(OnEnterRoom());
    }

    IEnumerator OnEnterRoom()
    {
        yield return new WaitForSeconds(0);
        TurnOnLights();
    }

    void TurnOnLights()
    {
        if (light2D == null)
            return;

        light2D.gameObject.SetActive(true);

    }
    
}
