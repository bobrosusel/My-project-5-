using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody;
    private PlayerAnimator _animator;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = new PlayerAnimator(GetComponent<Animator>());
    }

    private void FixedUpdate()
    {
        SetMovement();
    }
    
    private void SetMovement()
    {
        float movementHorizontal = Input.GetAxis("Horizontal");
        float movementVertical = Input.GetAxis("Vertical");

        Vector2 movementDirection = new Vector2(movementHorizontal, movementVertical);

        if (movementDirection == Vector2.zero)
        {
            _animator.SetMovement(false);
            return;
        }

        _animator.SetMovement(true);
        _rigidbody.MovePosition(_rigidbody.position + movementDirection * _speed * Time.fixedDeltaTime);
    }
}
