using Unity.VisualScripting;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField] Transform door;
    [SerializeField] float moveSpeed = 3f;

    private float targetY;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject doorObject = GameObject.FindWithTag("Door");

        if (doorObject != null)
        {
            door = doorObject.transform;
        }
        else
        {
            Debug.LogError("Could not find an object with the tag 'door'!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (door == null) return;

        // 1. Create a Vector3 representing the target local position
        Vector3 targetPosition = new Vector3(door.localPosition.x, targetY, door.localPosition.z);

        // 2. Move smoothly toward that position
        door.localPosition = Vector3.MoveTowards(door.localPosition, targetPosition, moveSpeed * Time.deltaTime);
    }

    public void DoorUp()
    {
        targetY = 4f;
    }

    public void DoorDown()
    {
        targetY = 0f;
    }



}
