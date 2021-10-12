using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public enum LookingDir
{
    Up,
    Down,
    Left,
    Right
        
}
public class PlayerContoller : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField]private float jumpforce = 1f;
    private Rigidbody2D _body;
    private bool flashlightSpawning;
    [SerializeField]private float movementSpeed = 3f;
    private Transform _transform;
    private LookingDir playerLookingDir = LookingDir.Right;
    [SerializeField] private GameObject flashlight;
    private Vector2 spawnPosition;
    public Animator animator;
    private static readonly int Speed = Animator.StringToHash("Speed");
    private static readonly int IsJumping = Animator.StringToHash("IsJumping");

    private void Update()
    {
        float movement = Input.GetAxisRaw("Horizontal");
        _transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * movementSpeed;

        animator.SetFloat(Speed, Mathf.Abs(movement));
        
        if (Input.GetButton("Jump") && Mathf.Abs(_body.velocity.y) <0.1f)
        {
            _body.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
            animator.SetBool(IsJumping, true);
        }

        if (transform.position.y < -5f)
        {
            _transform.position = new Vector3(transform.position.x, -4f);
            _body.velocity = Vector2.zero;
        }

        if (_body.velocity.x < 0f)
        {
            playerLookingDir = LookingDir.Right;
            
        }

        if (_body.velocity.x > -0.1f)
        {
            playerLookingDir = LookingDir.Left;
            
        }

        if (Input.GetButton("Fire2"))
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
        

    }
    
    private void Awake()
    {
        _transform = transform;
        _body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void PlayerLookingDirectionSight(out LookingDir lookingDir, out Vector3 position)
    {
        lookingDir = playerLookingDir;
        position = transform.position;
    }
}
