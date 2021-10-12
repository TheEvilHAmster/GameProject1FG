using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSensors : MonoBehaviour
{
    public float sightDistance = 5f; 
    public Rigidbody2D playerBody;
    private Vector3 oldPlayerPos;
    private Vector3 newPlayerPos;
    public SpringJoint2D sprintjoint2D;

    void Start() 
    {
        oldPlayerPos = this.transform.position;
        sprintjoint2D.enabled = false;   
    }
    void Update() 
    {
        

        if (Input.GetButton("Fire1"))
        {
            PlayerSight();
        } else {
            sprintjoint2D.enabled = false;
            FacingDirection();
        }
    }

    private void PlayerSight()
    {
        
        Vector3 currentPos = this.transform.position;
        currentPos.x += 1.5f;
        RaycastHit2D environmentInfo = Physics2D.Raycast(
            currentPos, 
            Vector2.right, 
            sightDistance);

        if (environmentInfo.collider == true) 
        {
            if (environmentInfo.collider.tag == "Moveable")
            {
                Debug.Log("A MOVEABLE");
                sprintjoint2D.enabled = true;
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
        }
        else if (newPlayerPos.x > oldPlayerPos.x) 
        {
            this.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        oldPlayerPos = this.transform.position;
    }

    void OnDrawGizmos() 
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, Vector2.right * sightDistance);
    }
    
    
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
