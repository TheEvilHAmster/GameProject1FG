using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Flashlight : MonoBehaviour
{
    
    
    [SerializeField]private Transform playerTransform;
    [SerializeField] float offset = 0f;
    [SerializeField]private int batteryLife = 100;
    
    [Range( 0f, 8f )] public float distanceFromGoal = 1;
    
    private Camera cam;
    private Rigidbody2D bodyOfFlashligt;
    private Rigidbody2D rigidBodyofParent;

    private Vector2 movement;
    private Vector2 mousePos;

    void Update()
    {


        Vector2 goalPos = playerTransform.position;
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        
        // Lochal Position of flashlight from player pos and mouse pos.
        Vector2 relPlayerPos = mousePos - goalPos;
        Vector2 dirToPlayer = relPlayerPos.normalized;

        
        
        Vector2 thingPos = dirToPlayer * distanceFromGoal; // calculate dot position along the direction
        Vector2 lokDir = mousePos - rigidBodyofParent.position;
        float angle = Mathf.Atan2(lokDir.y, lokDir.x) * Mathf.Rad2Deg + offset;
        bodyOfFlashligt.rotation = angle;
        transform.position = goalPos + thingPos;
        

        
        
        if (Input.GetButton("Fire2"))
        {
            gameObject.SetActive(true);

            
        }
        else
        {
            
            gameObject.SetActive(false);
        }
    }
    



    private void Awake()
    {
        cam = Camera.main;
        playerTransform = transform.parent;
        rigidBodyofParent = playerTransform.GetComponent<Rigidbody2D>();
        bodyOfFlashligt = transform.GetComponent<Rigidbody2D>();
    }
}