using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class AnimationChange : MonoBehaviour
{
    [SerializeField] private HurtBox _hurtBox;

    private GroundChecker _groundChecker;
    private Animator _animator;
    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _groundChecker = GetComponent<GroundChecker>();
    }

    private void Update()
    {
        _animator.SetFloat("XVelocity", Mathf.Abs(_rigidbody2D.velocity.x));
        _animator.SetFloat("YVelocity", _rigidbody2D.velocity.y);
        _animator.SetBool("IsHurt", _hurtBox.IsHurt);
        if (_groundChecker != null)
        {
            _animator.SetBool("IsGrounded", _groundChecker.IsGrounded);
        }
    }
}
