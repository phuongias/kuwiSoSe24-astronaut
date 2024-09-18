using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    public Sprite[] walkSprites; // Array von Lauf-Sprites
    [SerializeField] private float animationSpeed = 0.1f;
    public Sprite staySprite; // Stand-Sprite

    private PlayerControls playerControls;
    private Vector2 movement;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private int currentSpriteIndex = 0;
    private float timeSinceLastFrame = 0f;

    private Animator spriteAnimator;


    private void Awake()
    {
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteAnimator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        playerControls.Enable();
        playerControls.Movement.Move.performed += OnMove;
        playerControls.Movement.Move.canceled += OnMove;
    }

    private void OnDisable()
    {
        playerControls.Disable();
        playerControls.Movement.Move.performed -= OnMove;
        playerControls.Movement.Move.canceled -= OnMove;
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
        bool isMoving = movement != Vector2.zero;
        spriteAnimator.SetBool("IsMoving", isMoving); // Animator-Parameter setzen
        if (movement.x > 0)
        {
            spriteRenderer.flipX = false; // Face right
        }
        else if (movement.x < 0)
        {
            spriteRenderer.flipX = true; // Face left
        }
    }

    private void Move()
    {
        rb.velocity = movement * moveSpeed; // Geschwindigkeit basierend auf Eingabe setzen
    }

    private void AnimateMovement()
    {
        timeSinceLastFrame += Time.deltaTime;
        if (timeSinceLastFrame >= animationSpeed)
        {
            if (walkSprites.Length > 0)
            {
                currentSpriteIndex = (currentSpriteIndex + 1) % walkSprites.Length;
                spriteRenderer.sprite = walkSprites[currentSpriteIndex];
                timeSinceLastFrame = 0f;
            }
            else
            {
                Debug.LogError("walkSprites array is empty!");
            }
        }
    }

    private void Update()
    {
        bool isMoving = movement != Vector2.zero;
        Debug.Log($"Movement: {movement}, IsMoving: {isMoving}"); // Debug-Ausgabe

        if (isMoving)
        {
            AnimateMovement();
        }
        else
        {
            spriteRenderer.sprite = staySprite; // Zeigt das Stand-Sprite an
        }
    }


    private void FixedUpdate()
    {
        Move();
    }
}
