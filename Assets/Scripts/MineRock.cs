using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineRock : MonoBehaviour
{
    private Animator playerAnimator;
    private bool isColliding = false;

    private void Start()
    {
        // Findet den Animator des Players (vorausgesetzt der Player hat einen Tag "Player")
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerAnimator = player.GetComponent<Animator>();
        }
        else
        {
            Debug.LogError("Player not found!");
        }
    }

    

   
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))  
        {
            new WaitForSeconds(0.5f);
            isColliding = true;
            Debug.Log("Player collided");
        }
    }

   
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isColliding = false;
            playerAnimator.SetBool("IsCollidingWithRock", isColliding);
            playerAnimator.SetBool("IsCollidingWithRockAndKeyPress", isColliding);
            Debug.Log("Player not collided any longer");
        }
    }

   
    void Update()
    {
        if (isColliding && !Input.GetKeyDown(KeyCode.E))
        {
            if (playerAnimator != null)
            {
                playerAnimator.SetBool("IsCollidingWithRock", isColliding);
                Debug.Log("Player colliding, playing Think animation");
            }
        }

        if (isColliding && Input.GetKeyDown(KeyCode.E))  
        {
            playerAnimator.SetBool("IsCollidingWithRockAndKeyPress", isColliding);
            Debug.Log("Player colliding + Keypress, playing Mine animation");
            Destroy(gameObject, 3f);
            isColliding = false;
            //playerAnimator.SetBool("IsCollidingWithRockAndKeyPress", isColliding);
        }
    }
}
