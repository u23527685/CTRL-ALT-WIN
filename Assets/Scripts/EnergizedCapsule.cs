using UnityEngine;
using UnityEngine.Events;

public class EnergizedCapsule : MonoBehaviour
{
    [SerializeField] Light light;
    public UnityEvent objectActionStart;
    public UnityEvent objectActionStop;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        light = GetComponentInChildren<Light>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LightOff()
    {
        light.enabled = false;
        objectActionStop?.Invoke();
    }

    public void LightOn()
    {
        light.enabled = true;
        objectActionStart?.Invoke();
    }
}
