using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody;
    private PlayerAnimator _animator;

    private Vector2 _currentMovement;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = new PlayerAnimator(GetComponent<Animator>());
    }

    private void FixedUpdate()
    {
        SetMovement(_currentMovement);
    }

    private void SetMovement(Vector2 movementDirection)
    {

        if (movementDirection == Vector2.zero)
        {
            _animator.SetMovement(false);
            return;
        }

        _animator.SetMovement(true);
        _rigidbody.MovePosition(_rigidbody.position + movementDirection * _speed * Time.fixedDeltaTime);
    }

    private void OnMoveInput(Vector2 movementDirection)
    {
        _currentMovement = movementDirection;
    }

    private void OnEnable()
    {
        InputCheker.Input.Move += OnMoveInput;
    }

    private void OnDisable()
    {
        InputCheker.Input.Move -= OnMoveInput;
    }
}
