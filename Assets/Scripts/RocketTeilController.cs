using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RocketTeilController : MonoBehaviour

{
    [SerializeField] public TextMeshProUGUI progressText;
    public static int totalParts = 3;
    public static int partsPickedUp = 0;

    [SerializeField] private TextMeshProUGUI pickUpText;
    private bool pickUpAllowed;

    [SerializeField] private GameObject messagePanel;
    [SerializeField] private TextMeshProUGUI messageText;
    private List<string> infoMessages;

    private void Start()
    {
        pickUpText.gameObject.SetActive(false);
        messageText.gameObject.SetActive(false);
        messagePanel.SetActive(false);

        UpdateProgressText();
        InitializeMessages();
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
        partsPickedUp++;
        UpdateProgressText();
        ShowInfoMessage(partsPickedUp - 1);
        Destroy(gameObject);
    }

    private void UpdateProgressText()
    {
        if (progressText != null)
        {
            progressText.text = $"{partsPickedUp} von {totalParts} Raketenteile eingesammelt.";
            if (partsPickedUp == totalParts)
            {
                progressText.text = $"Alle {totalParts} Raketenteile eingesammelt.";
            }
        }
    }

    private void InitializeMessages()
    {
        infoMessages = new List<string>
        {
            "Gut gemacht! Wusstest du, dass der Mond keine Atmosphäre hat?",
            "Klasse! Hättest du gedacht, dass ......",
            "Super! Vielleicht sind wir nicht die einzigen Lebenden im Universum...!"
        };
    }

    private void ShowInfoMessage(int messageIndex)
    {
        if (messageIndex >= 0 && messageIndex < infoMessages.Count)
        {
            messageText.text = infoMessages[messageIndex];
            messagePanel.SetActive(true);
            messageText.gameObject.SetActive(true);
            StartCoroutine(HideMessageAfterKeyPress(5f));
        }
    }

    private IEnumerator HideMessageAfterKeyPress(float delay)
    {
        yield return new WaitForSeconds(delay);
        messagePanel.SetActive(false);
        messageText.gameObject.SetActive(false);
    }
}
