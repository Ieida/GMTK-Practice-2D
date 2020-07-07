using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] GroundDetection groundDetection;
    [Space]

    [SerializeField] float speed;

    Vector2 input;

    private void OnEnable() {
        if (rb == null && !TryGetComponent(out rb)) this.enabled = false;
        if (groundDetection == null && !TryGetComponent(out groundDetection)) this.enabled = false;
    }

    private void Update() {
        input = new Vector2(Input.GetAxis("Horizontal"), 0.0f);
    }

    private void FixedUpdate() {
        if (!groundDetection.IsGrounded) return;
        Vector2 velocity = input * speed;
        velocity.y = rb.velocity.y;
        rb.velocity = velocity;
    }
}
