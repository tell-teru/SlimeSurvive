using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5.0f;
    public float rotationSpeed = 100.0f;

    private Rigidbody rb;
    private Vector3 m_EulerAngleVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0, -30, 0);
        m_EulerAngleVelocity = new Vector3(0, 100, 0);
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = transform.forward * movement.z * speed;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Quaternion deltaRotation = Quaternion.Euler(-m_EulerAngleVelocity * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }
    }
}
