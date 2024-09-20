using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildRocket : MonoBehaviour
{
    [SerializeField]
    public Image progressImage;

    [SerializeField]
    private TextMeshProUGUI buildRocketText;
    private bool buildingAllowed;
    bool SeeFirstTime = true;


    // Start is called before the first frame update
    void Start()
    {
        progressImage.gameObject.SetActive(false);
        buildRocketText.gameObject.SetActive(false); // Text wird zu Beginn deaktiviert
        
    }

    void Update()
    {
        // �berpr�fe, ob der Spieler im Triggerbereich ist und E dr�ckt
        if (buildingAllowed && Input.GetKeyDown(KeyCode.E))
        {
            int collectedParts = RocketTeilController.partsPickedUp;



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
            int collectedParts = RocketTeilController.partsPickedUp;
            buildingAllowed = true; // Spieler ist im Triggerbereich

            if (SeeFirstTime == true)
            {
                progressImage.gameObject.SetActive(true);
                buildRocketText.text = "Das ist von der Rakete �brig... Ich sollte die fehlenden Teile suchen und hier herbringen.";
            }
            buildRocketText.gameObject.SetActive(true); // Text wird 

            if (SeeFirstTime == false)
            {
                buildRocketText.text = "Der Rakete fehlen wichtige Teile...";
            }

            if (collectedParts == RocketTeilController.totalParts)
            {
                buildRocketText.text = "Dr�cke 'e', um die Rakete zusammenzubauen.";
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            buildingAllowed = false; // Spieler verl�sst den Triggerbereich
            buildRocketText.gameObject.SetActive(false); // Text wird ausgeblendet
            if (SeeFirstTime == true)
            {
                SeeFirstTime = false;
            }
        }
    }

    private void baueRakete()
    {
        buildRocketText.text = "Rakete wird gebaut...";
        // F�ge hier weitere Logik f�r den Raketenbau hinzu
        Debug.Log("Raketenbau gestartet");
    }
}
