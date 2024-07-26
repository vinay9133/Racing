using UnityEngine;

public class CarController : MonoBehaviour
{
    public float speed = 10f;            // Car's forward speed
    public float turnSpeed = 50f;        // Car's turning speed
    public float maxSpeed = 50f;         // Car's maximum speed
    public float drag = 0.98f;           // Car's drag factor

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.drag = drag;
    }

    void Update()
    {
        float move = Input.GetAxis("Vertical"); // W/S or Up/Down keys
        float turn = Input.GetAxis("Horizontal"); // A/D or Left/Right keys

        // Apply forward and backward movement
        Vector3 forwardMovement = transform.forward * move * speed * Time.deltaTime;
        rb.AddForce(forwardMovement, ForceMode.VelocityChange);

        // Apply turning
        float turnAmount = turn * turnSpeed * Time.deltaTime;
        Quaternion turnOffset = Quaternion.Euler(0, turnAmount, 0);
        rb.MoveRotation(rb.rotation * turnOffset);

        // Limit the car's speed
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }
}
