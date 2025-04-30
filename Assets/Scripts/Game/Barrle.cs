using System;
using UnityEngine;

public class Barrle : MonoBehaviour, IHealth
{
    [SerializeField] private float _damage;

    private float _health = 1;
    public void TakeDamage(float damage)
    {
        _health = Math.Max(0, _health - damage);
        if (_health == 0)
        {
            Destroy(gameObject);
            Boom();
        }
    }

    private void Boom()
    {
        Collider2D[] health = Physics2D.OverlapCircleAll(transform.position, GetComponent<CircleCollider2D>().radius);
        foreach (Collider2D h in health)
        {
            if (h.TryGetComponent<IHealth>(out IHealth component))
                component.TakeDamage(_damage);
        }
    }
}
