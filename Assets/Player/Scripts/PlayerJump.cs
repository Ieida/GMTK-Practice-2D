using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] GroundDetection groundDetection;
    [Space]

    [SerializeField] float force;
    [SerializeField] ForceMode2D forceMode;

    bool input;

    private void OnEnable() {
        if (rb == null && !TryGetComponent(out rb)) this.enabled = false;
        if (groundDetection == null && !TryGetComponent(out groundDetection)) this.enabled = false;
    }

    private void Update() {
        if (!input) input = Input.GetButtonDown("Jump");
    }

    private void FixedUpdate() {
        if (input && groundDetection.IsGrounded)
        {
            rb.AddForce(Vector2.up * force, forceMode);
            input = false;
        }
    }
}
