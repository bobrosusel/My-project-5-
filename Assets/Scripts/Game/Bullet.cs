using UnityEngine;

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
        if (collision.gameObject.TryGetComponent<Health>(out Health health))
        {
            health.TakeDamage(_damage);
            Destroy(gameObject);
        }
        else
        {
            Vector2 normal = collision.contacts[0].normal;

            Vector2 reflectedDirection = Vector2.Reflect(_rigidbody.linearVelocity.normalized, normal);

            _rigidbody.linearVelocity = reflectedDirection * _bulletSpeed;

            float angle = Mathf.Atan2(reflectedDirection.y, reflectedDirection.x) * Mathf.Rad2Deg - 90f;
            transform.rotation = Quaternion.Euler(0, 0, angle);
            
        }
    }

    public void SetProperties(float damage)
    {
        _damage = damage;
    }
}
