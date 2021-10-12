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
    private BoxCollider2D colider;
    private Rigidbody2D _body;
    private bool flashlightSpawning;
    [SerializeField]private float movementSpeed = 3f;
    private Transform _transform;
    
    [SerializeField] private GameObject flashlight;
    private Vector2 spawnPosition;
    public Animator animator;
    private static readonly int Speed = Animator.StringToHash("Speed");
    private static readonly int IsJumping = Animator.StringToHash("IsJumping");
    public LayerMask furnitureLayerMask;
    
    private void Update()
    {
        float movement = Input.GetAxisRaw("Horizontal");
        _transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * movementSpeed;

        animator.SetFloat(Speed, Mathf.Abs(movement));
        
        if (Input.GetButton("Jump") && IsGrounded() && _body.velocity.y < 0.01f )
        {
            _body.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
            animator.SetBool(IsJumping, true);
        }

        if (transform.position.y < -5f)
        {
            _transform.position = new Vector3(transform.position.x, -4f);
            _body.velocity = Vector2.zero;
        }
        

        if (Input.GetButton("Fire2"))
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
        
        animator.SetBool(IsJumping, !IsGrounded());
        

    }
    
    private void Awake()
    {
        _transform = transform;
        _body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        colider = GetComponent<BoxCollider2D>();
    }

    bool IsGrounded()
    {
        float extraHeight = 0.1f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(colider.bounds.center, colider.bounds.size, 0f,
            Vector2.down, extraHeight, furnitureLayerMask);
        
        return (raycastHit.collider != null);

    }
    
}
