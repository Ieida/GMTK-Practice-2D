using UnityEngine;

public class GroundDetection : MonoBehaviour
{
    public bool IsGrounded { get; private set; }

    [SerializeField] float distance;
    [SerializeField] LayerMask groundLayers;

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, -transform.up * distance);
    }

    private void Update() {
        IsGrounded = Physics2D.Raycast(transform.position, -transform.up, distance, groundLayers);
    }
}
