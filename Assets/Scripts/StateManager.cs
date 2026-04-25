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

    [Header("Game Objects")]
    [SerializeField] Transform player;
    [SerializeField] Transform groundCheck;
    [SerializeField] Transform chargeBase;

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
        if (playerOnChargeBase)
        {
            onAbsorb?.Invoke();
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
        if (playerOnChargeBase)
        {
            onRelease?.Invoke();
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
