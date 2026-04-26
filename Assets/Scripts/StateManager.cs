using UnityEngine;
using UnityEngine.Events;

public class StateManager : MonoBehaviour
{
    public UnityEvent onAbsorb;
    public UnityEvent onRelease;
    [Header("energy manipulation")]
    public bool playerAbsorbing = false;
    public bool playerAbsorbed = false;
    public bool playerOnChargeBase = false;
    public bool playerReleasing = false;
    public bool playerReleased = false;

    [Header("Game Objects & Scripts")]
    [SerializeField] PlayerController player; // Reference to the Player
    [SerializeField] EnergyNode currentEnergyNode; // Reference to the object's script

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void StartAbsorb()
    {
        playerAbsorbing=true;
        //begin sound
    }

    public void Absorb()
    {
        playerAbsorbed = true;
        if (playerOnChargeBase && currentEnergyNode != null)
        {
            if (currentEnergyNode.energized)
            {
                Debug.Log("Absorbing Energy!");
                if (currentEnergyNode.blueEnergy)
                    player.blueEnergy += currentEnergyNode.energygive;
                else
                    player.YellowEnergy += currentEnergyNode.energygive;
                onAbsorb?.Invoke();
            }
            else
            {
                Debug.Log("This object has no energy to absorb.");
            }
        }
    }

    public void cancelAbsorb()
    {
        playerAbsorbing = false;
        playerAbsorbed = false;
    }

    public void StartRelease()
    {
        playerReleasing = true;
        //begin sound
    }

    public void Release()
    {
        playerReleased = true;
        if (playerOnChargeBase && currentEnergyNode != null)
        {
            float currentEnergy;
            if (currentEnergyNode.blueEnergy)
                currentEnergy = player.blueEnergy;
            else
                currentEnergy = player.YellowEnergy;    
            if (currentEnergy >= currentEnergyNode.neededEnergy)
            {
                Debug.Log("Releasing Energy!");
                if (currentEnergyNode.blueEnergy)
                    player.blueEnergy -= currentEnergyNode.neededEnergy;
                else
                    player.YellowEnergy -= currentEnergyNode.neededEnergy;
                onRelease?.Invoke();
            }
            else
            {
                Debug.Log("Not enough energy to release!");
            }
        }
    }

    public void Cancelrelease()
    {
        playerReleasing = false;
        playerReleased = false;
    }

    public void OnCharge()
    {
        playerOnChargeBase=true;
        if (playerAbsorbed)
        {
            onAbsorb?.Invoke();
        }
        if (playerReleased)
        {
            onRelease?.Invoke();
        }
    }

    public void OffCharge()
    {
        playerOnChargeBase = false;
    }
}
