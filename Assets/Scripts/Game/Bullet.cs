using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _lifeTime;
    [SerializeField] private float _bulletSpeed;

    private Rigidbody2D _rigidbody;

    private float _damage;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.linearVelocity = -transform.up * _bulletSpeed;
    }
    private void FixedUpdate()
    {
        _lifeTime -= Time.deltaTime;
        if (_lifeTime <= 0)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<IHealth>(out IHealth health))
        {
            health.TakeDamage(_damage);
            Destroy(gameObject);
        }
        else
        {
            Vector2 normal = collision.contacts[0].normal;
            Vector2 reflectedVelocity = Vector2.Reflect(_rigidbody.linearVelocity.normalized, normal) * _bulletSpeed;
            _rigidbody.linearVelocity = -reflectedVelocity;

            float angle = Mathf.Atan2(reflectedVelocity.y, reflectedVelocity.x) * Mathf.Rad2Deg - 90f; 
            transform.Rotate(new Vector3(0, 0, angle));
        }
    }

    public void SetProperties(float damage)
    {
        _damage = damage;
    }
}
