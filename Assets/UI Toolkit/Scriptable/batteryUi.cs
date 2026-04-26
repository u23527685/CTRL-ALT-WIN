using UnityEngine;

[CreateAssetMenu(fileName ="BatterData", menuName ="ScriptableObject/BatteryData")]
public class batteryUi : ScriptableObject
{
    public string energyType;
    public float energy;
}
