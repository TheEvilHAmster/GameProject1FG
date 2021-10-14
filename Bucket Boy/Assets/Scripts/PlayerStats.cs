using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{

    public float maxBatteryLevel = 100f;
    public float currentBatteryLevel;
    public BatteryLevel batteryLevel;
    public GameObject Battery;
    public float flashlightUsage = 0.02f;
    public float batteryPickup = 20f;
    public float enemyPowerDrain = 10f;

    void Start()
    {
        currentBatteryLevel = maxBatteryLevel;
        batteryLevel.SetMaxBatteryLevel(maxBatteryLevel);
    }

    void Update()
    {
        if (currentBatteryLevel > 0)
        {
            PowerDepletion();
        } else {
            SceneManager.LoadScene("GameOverScene");
        }
    }

    void PowerDepletion()
    {
        if (Input.GetButton("Fire2"))
        {
            currentBatteryLevel -= flashlightUsage;
            batteryLevel.SetBatteryLevel(currentBatteryLevel);
        }
    }

    void OnTriggerEnter2D(Collider2D collisionInfo) {
        if(collisionInfo.gameObject.tag == "Battery")
        {
            currentBatteryLevel += batteryPickup;
            if (currentBatteryLevel > maxBatteryLevel)
            {
                currentBatteryLevel = maxBatteryLevel;
            }
            batteryLevel.SetBatteryLevel(currentBatteryLevel);
            Destroy(collisionInfo.gameObject);
        }
        else if(collisionInfo.gameObject.tag == "Enemy")
        {
            currentBatteryLevel -= enemyPowerDrain;
            batteryLevel.SetBatteryLevel(currentBatteryLevel);     
        }
    }
}
