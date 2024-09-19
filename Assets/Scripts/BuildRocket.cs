using TMPro;
using UnityEngine;

public class BuildRocket : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI buildRocketText;
    private bool buildingAllowed;

    // Start is called before the first frame update
    void Start()
    {
        buildRocketText.gameObject.SetActive(false); // Text wird zu Beginn deaktiviert
    }

    void Update()
    {
        // �berpr�fe, ob der Spieler im Triggerbereich ist und E dr�ckt
        if (buildingAllowed && Input.GetKeyDown(KeyCode.E))
        {
            int collectedParts = RocketTeilController.partsPickedUp;

            // Wenn alle Teile gesammelt wurden
            if (collectedParts == RocketTeilController.totalParts)
            {
                baueRakete();
            }
            else
            {
                buildRocketText.text = "Der Rakete fehlen wichtige Teile...";
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            buildingAllowed = true; // Spieler ist im Triggerbereich
            buildRocketText.gameObject.SetActive(true); // Text wird aktiviert

            int collectedParts = RocketTeilController.partsPickedUp;

            // Pr�fe, ob alle Teile gesammelt wurden
            if (collectedParts == RocketTeilController.totalParts)
            {
                buildRocketText.text = "Dr�cke 'E', um die Rakete zu bauen.";
            }
            else
            {
                buildRocketText.text = "Der Rakete fehlen wichtige Teile...";
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            buildingAllowed = false; // Spieler verl�sst den Triggerbereich
            buildRocketText.gameObject.SetActive(false); // Text wird ausgeblendet
        }
    }

    private void baueRakete()
    {
        buildRocketText.text = "Rakete wird gebaut...";
        // F�ge hier weitere Logik f�r den Raketenbau hinzu
        Debug.Log("Raketenbau gestartet");
    }
}
