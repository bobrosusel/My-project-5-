using System.Collections;
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

        StartCoroutine(TimeLifeTimer());
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IHealth health))
        {
            HitLogic(health);
        }
        else
        {
            ReflectBullet(collision);
        }
    }

    private void HitLogic(IHealth health)
    {
        health.TakeDamage(_damage);
        Destroy(gameObject);
    }
    private void ReflectBullet(Collision2D collision)
    {
        Vector2 normal = collision.contacts[0].normal.normalized;

        Vector2 incomingDir = _rigidbody.linearVelocity.normalized;

        Vector2 reflectedDir = Vector2.Reflect(incomingDir, normal);

        float angle = Mathf.Atan2(reflectedDir.y, reflectedDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private IEnumerator TimeLifeTimer()
    {
        yield return new WaitForSeconds(_lifeTime);
        Destroy(gameObject);
    }

    public void SetProperties(float damage)
    {
        _damage = damage;
    }
}
