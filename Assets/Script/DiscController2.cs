using UnityEngine;

public class MovementAndRotation2D : MonoBehaviour
{
    public float speed = 1f;
    public float rotationAngle = 90f;

    [Header("Rotation")]
    public Transform m_rotationHandler;
    [SerializeField] private float m_rotationSpeed = 25;

    private void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        m_rotationHandler.Rotate(Vector3.forward * m_rotationSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
            transform.Rotate(Vector3.forward, rotationAngle);
        }
    }
}
