using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _lifeTime;

    private Rigidbody2D _rigidbody;

    private float _damage;
    private float _bulletSpeed;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        _rigidbody.linearVelocity = -transform.up * _bulletSpeed;
    }

    public void SetProperties(float bulletSpeed, float damage)
    {
        _bulletSpeed = bulletSpeed;
        _damage = damage;
    }
}
