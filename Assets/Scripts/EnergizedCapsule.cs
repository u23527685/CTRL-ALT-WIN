using UnityEngine;
using UnityEngine.Events;

public class EnergizedCapsule : EnergyNode
{
    public UnityEvent objectActionStart;
    public UnityEvent objectActionStop;

    // We override the base methods to add the UnityEvents
    public override void ReceiveEnergy()
    {
        base.ReceiveEnergy(); // This calls the light & energy logic from the Base Class
        objectActionStart?.Invoke();
    }

    public override void DrainEnergy()
    {
        base.DrainEnergy();
        objectActionStop?.Invoke();
    }
}