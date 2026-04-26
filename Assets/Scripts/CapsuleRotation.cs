using UnityEngine;

public class CapsuleRotation : MonoBehaviour
{
    [Header("Rotation Settings")]
    Vector3 rotationSpeed = new Vector3(0f, 0f, 180f);

    private bool isRotating=true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        if (isRotating)
        {
            // Time.deltaTime ensures it spins at the same speed regardless of framerate
            transform.Rotate(rotationSpeed * Time.deltaTime);
        }
    }

    public void Rotate()
    {
        isRotating = true;
    }

    public void Stop()
    {
        isRotating = false ;
    }
}
