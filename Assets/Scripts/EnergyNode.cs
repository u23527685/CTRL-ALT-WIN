using UnityEngine;

public class EnergyNode : MonoBehaviour
{
    [Header("Base Energy Settings")]
    public float neededEnergy = 50f;
    public float energygive = 50f;
    public bool energized;

    public bool blueEnergy = false;

    public float currentEnergy;
    protected Light nodeLight; // 'protected' means only child scripts can see this

    // 'virtual' allows child scripts to run this AND add their own code
    protected virtual void Start()
    {
        // Automatically find the light on this object or its children
        nodeLight = GetComponentInChildren<Light>();
        if (nodeLight == null) nodeLight = GetComponent<Light>();

        // Set up the initial energy state based on the light
        if (nodeLight != null)
        {
            energized = nodeLight.enabled;
        }

        currentEnergy = energized ? energygive : 0;
    }

    // Standardized methods for the StateManager to call
    public virtual void ReceiveEnergy()
    {
        energized = true;
        currentEnergy = energygive;
        if (nodeLight != null) nodeLight.enabled = true;
    }

    public virtual void DrainEnergy()
    {
        energized = false;
        currentEnergy = 0;
        if (nodeLight != null) nodeLight.enabled = false;
    }
}