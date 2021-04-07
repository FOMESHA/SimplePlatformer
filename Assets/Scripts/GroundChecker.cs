using UnityEngine;


public class GroundChecker : MonoBehaviour
{
    [SerializeField] private LayerMask _groundLayer;

    private bool _isGrounded;

    public bool IsGrounded => _isGrounded;

    private void FixedUpdate()
    {
        _isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 0.6f, _groundLayer);
    }
}
