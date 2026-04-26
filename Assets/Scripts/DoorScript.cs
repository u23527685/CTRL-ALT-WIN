using UnityEngine;

public class DoorScript : EnergyNode
{
    [SerializeField] Transform door;
    [SerializeField] float moveSpeed = 3f;
    private float targetY;

    protected override void Start()
    {
        base.Start(); // Run the Base Class setup first!

        GameObject doorObject = GameObject.FindWithTag("Door");
        if (doorObject != null)
        {
            door = doorObject.transform;
            targetY = door.localPosition.y; // Set starting height
        }
        else
        {
            Debug.LogError("Could not find an object with the tag 'door'!");
        }
    }

    void Update()
    {
        if (door == null) return;
        Vector3 targetPosition = new Vector3(door.localPosition.x, targetY, door.localPosition.z);
        door.localPosition = Vector3.MoveTowards(door.localPosition, targetPosition, moveSpeed * Time.deltaTime);
    }

    public override void ReceiveEnergy() // Replaces DoorUp()
    {
        base.ReceiveEnergy();
        targetY = 4f;
    }

    public override void DrainEnergy() // Replaces DoorDown()
    {
        base.DrainEnergy();
        targetY = 0f;
    }
}