using UnityEngine;
using UnityEngine.Events;

public class Charging : MonoBehaviour
{
    public UnityEvent onChargeBaseEnter;
    public UnityEvent onChargeBaseExit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            onChargeBaseEnter?.Invoke();

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            onChargeBaseExit?.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
