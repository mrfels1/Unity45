using UnityEngine;

public class BallController : MonoBehaviour
{
    public float moveForce = 10f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // A/D или ←/→
        
        Vector3 force = new Vector3(moveHorizontal, 0, 0); // движение только по X
        rb.AddForce(force * moveForce);
    }
}
