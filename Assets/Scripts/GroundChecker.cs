using UnityEngine;


public class GroundChecker : MonoBehaviour
{
    [SerializeField] private LayerMask _groundLayer;
    public bool IsGrounded => _isGrounded;

    private bool _isGrounded;

    private void FixedUpdate()
    {
        _isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 1f, _groundLayer);
    }
}
