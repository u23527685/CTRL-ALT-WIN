using UnityEngine;
using TMPro; // This is required to talk to TextMeshPro!

public class UIManager : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] TextMeshProUGUI BlueErgyText;
    [SerializeField] TextMeshProUGUI YellowEnergyText;

    [Header("Game References")]
    [SerializeField] PlayerController player;

    void Start()
    {
        // Update the text right when the game starts so it doesn't say "New Text"
        UpdateEnergyUI();
    }

    // We will call this method whenever the player's energy changes
    public void UpdateEnergyUI()
    {
        if (player != null && BlueErgyText != null && YellowEnergyText!=null)
        {
            BlueErgyText.text = "Blue Energy: " + player.blueEnergy.ToString();
            YellowEnergyText.text = "Yellow Energy: "+ player.YellowEnergy.ToString();

        }
        else
        {
            Debug.LogWarning("UIManager is missing a reference to the Player or the Text!");
        }
    }
}