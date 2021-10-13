using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform playerTransform;
    public float smoothSpeed = 3f;
    public Vector3 offset;

    void LateUpdate() 
    {
        Vector3 desiredPosition = playerTransform.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
    
    /*[SerializeField] private Transform playerTransform;
    private Camera _camera;
    [SerializeField] private float maxHiegtOfCamera = 411;
    [SerializeField] private float minHeightOfCamera = 0;

    // Update is called once per frame
    void Update()
    {

        if (playerTransform.position.y > minHeightOfCamera)
        {
            transform.position = new Vector3(transform.position.x, playerTransform.position.y, -10f); 
        }
        else if (playerTransform.position.y < minHeightOfCamera)
        {
            transform.position = new Vector3(transform.position.x, minHeightOfCamera, -10f);
        }
        if (playerTransform.position.y  > maxHiegtOfCamera)
        {
            transform.position = new Vector3(transform.position.x, maxHiegtOfCamera, -10);
        }

        
    }

    private void Awake()
    {
        _camera = Camera.main;
    }*/
}
