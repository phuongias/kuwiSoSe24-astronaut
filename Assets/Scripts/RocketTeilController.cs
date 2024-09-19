using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TeilSpitzeController : MonoBehaviour

{
    [SerializeField]
    private TextMeshProUGUI progressText; 
    private static int totalParts = 3; 
    private static int partsPickedUp = 0; 

    [SerializeField]
    private TextMeshProUGUI pickUpText;
    private bool pickUpAllowed;

    private void Start()
    {
        pickUpText.gameObject.SetActive(false);
        UpdateProgressText();
    }

    private void Update()
    {
        if (pickUpAllowed && Input.GetKeyDown(KeyCode.E))
            PickUp();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            pickUpText.gameObject.SetActive(true);
            pickUpAllowed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            pickUpText.gameObject.SetActive(false);
            pickUpAllowed = false;
        }
    }

    private void PickUp()
    {
        partsPickedUp++; // Erhöhe die Anzahl der gesammelten Teile
        UpdateProgressText();
        Destroy(gameObject);
    }
    
    private void UpdateProgressText()
    {
        if (progressText != null)
        {
            progressText.text = $"{partsPickedUp}/{totalParts} Rocket Parts";
        }
    }
}
