using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSensors : MonoBehaviour
{
    public float sightDistance = 5f; 
    private bool isFacingLeft;
    private Vector2 facingDirection;
    public Transform grabbers;
    public GameObject flashlight;

    void Start() 
    {
        isFacingLeft = false;  
    }
    
    void Update() 
    {   
        PlayerSight();
        
        if (!Input.GetButton("Fire1"))
        {
            FacingDirection();
        }
    }

    private void PlayerSight()
    {
        Vector3 currentPos = grabbers.position;
        
        if (isFacingLeft == true)
        {
            facingDirection = Vector2.left;
        } else {
            facingDirection = Vector2.right;
        }

        RaycastHit2D environmentInfo = Physics2D.Raycast(
            currentPos, 
            facingDirection, 
            sightDistance);

        if (environmentInfo.collider == true && environmentInfo.collider.tag == "Moveable") 
        {
            if (Input.GetButton("Fire1"))
            {
                environmentInfo.collider.gameObject.transform.parent = grabbers;
                environmentInfo.collider.gameObject.transform.position = grabbers.position;
                environmentInfo.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            } else {
               environmentInfo.collider.gameObject.transform.parent = null;
               environmentInfo.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            }
        }
    }

    private void FacingDirection()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            this.transform.localRotation = Quaternion.Euler(0, -180, 0);
            flashlight.transform.localRotation = Quaternion.Euler(0, -180, 0);
            isFacingLeft = true;
        }
        else if (Input.GetKeyDown(KeyCode.D)) 
        {
            this.transform.localRotation = Quaternion.Euler(0, 0, 0);
            flashlight.transform.localRotation = Quaternion.Euler(0, 0, 0);
            isFacingLeft = false;
        }
    }
}
