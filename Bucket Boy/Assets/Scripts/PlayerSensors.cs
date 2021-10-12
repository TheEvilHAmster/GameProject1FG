using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSensors : MonoBehaviour
{
    public float sightDistance = 5f; 
    public Rigidbody2D playerBody;
    private Vector3 oldPlayerPos;
    private Vector3 newPlayerPos;
    public FixedJoint2D fixedJoint2D;
    private bool isFacingLeft;
    private Vector2 facingDirection;
    public GameObject Moveable; 

    void Start() 
    {
        oldPlayerPos = this.transform.position;
        fixedJoint2D.enabled = false;
        isFacingLeft = false;   
    }
    void Update() 
    {
        

        if (Input.GetButton("Fire1"))
        {
            PlayerSight();
        } else {
            fixedJoint2D.enabled = false;
            FacingDirection();
        }
    }

    private void PlayerSight()
    {
        Vector3 currentPos = this.transform.position;
        
        if (isFacingLeft == true)
        {
            facingDirection = Vector2.left;
            currentPos.x -= 1.5f;
        } else {
            facingDirection = Vector2.right;
            currentPos.x += 1.5f;
        }

        RaycastHit2D environmentInfo = Physics2D.Raycast(
            currentPos, 
            facingDirection, 
            sightDistance);

        if (environmentInfo.collider == true) 
        {
            if (environmentInfo.collider.tag == "Moveable")
            {
                Debug.Log("A MOVEABLE");
                fixedJoint2D.enabled = true;
                Moveable.GetComponent<FixedJoint2D>().enabled = true;
                Moveable.GetComponent<FixedJoint2D>().connectedBody = playerBody;
                //transform.Translate(
                //    Vector2.right * enemySpeed * Time.deltaTime);
            }   
        }
    }

    private void FacingDirection()
    {
        newPlayerPos = this.transform.position;
        Debug.Log(newPlayerPos.x);
        if (newPlayerPos.x < oldPlayerPos.x)
        {
            this.transform.localRotation = Quaternion.Euler(0, 180, 0);
            isFacingLeft = true;
        }
        else if (newPlayerPos.x > oldPlayerPos.x) 
        {
            this.transform.localRotation = Quaternion.Euler(0, 0, 0);
            isFacingLeft = false;
        }
        oldPlayerPos = this.transform.position;
    }

    /*void OnDrawGizmos() 
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, Vector2.right * sightDistance);
    }*/
    
    
    /*
    While (MouseButton Fire1 is held down)
    {
        Call PlayerSight
            if collider.tag == "Moveable"
            {
                MovealbeMovesWithPlayer = true;
            }
    }
    */ 
}
