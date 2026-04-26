using UnityEngine;

public class BoxFloat : EnergyNode
{
    private Rigidbody rb;
    [SerializeField] Transform floatPosition;
    private bool floatBool;

    protected override void Start()
    {
        base.Start(); // Run the Base Class setup first!
        rb = GetComponent<Rigidbody>();
        floatBool = false;
    }

    public override void ReceiveEnergy() // Replaces FloatObj()
    {
        base.ReceiveEnergy();
        floatBool = true;
        rb.useGravity = false;
        rb.linearVelocity = Vector3.zero; // Stop momentum before floating
    }

    public override void DrainEnergy() // Replaces Drop()
    {
        base.DrainEnergy();
        floatBool = false;
        rb.useGravity = true;
    }

    private void FixedUpdate()
    {
        if (floatBool && floatPosition != null)
        {
            float lerpSpeed = 5f;
            // Swapped to fixedDeltaTime and rb.position for smooth physics
            Vector3 newPosition = Vector3.Lerp(rb.position, floatPosition.position, Time.fixedDeltaTime * lerpSpeed);
            rb.MovePosition(newPosition);
        }
    }
}