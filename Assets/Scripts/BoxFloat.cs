using UnityEngine;

public class BoxFloat : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 position;
    private bool floatBool=false;
    [SerializeField] Transform floatPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb= GetComponent<Rigidbody>();
        position=transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (floatBool)
        {
            FixedUpdate();
        }
    }

    public void FloatObj()
    {
        floatBool = true;
        rb.useGravity = false;
    }

    public void Drop()
    {
        floatBool = false;
        rb.useGravity = true;
    }

    private void FixedUpdate()
    {
        if (floatPosition != null)
        {
            float lerpSpeed = 10f;
            Vector3 newPosition= Vector3.Lerp(transform.position, floatPosition.position, Time.deltaTime* lerpSpeed);
            rb.MovePosition(newPosition);
        }
    }
}
