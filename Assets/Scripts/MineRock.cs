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
            isColliding = true;
        }
    }

   
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isColliding = false;
        }
    }

   
    void Update()
    {
        if (isColliding)
        {
            if (playerAnimator != null)
            {
                playerAnimator.SetTrigger("PlayMineThinkAnimation"); 
            }
        }

        if (isColliding && Input.GetKeyDown(KeyCode.E))  
        {
            Destroy(gameObject, 2.5f);  
        }
    }
}
