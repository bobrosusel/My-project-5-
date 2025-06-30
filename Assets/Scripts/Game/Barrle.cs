using System;
using UnityEngine;

public class BarrleHealth : MonoBehaviour, IHealth
{
    [SerializeField] private float _damage;
    [SerializeField] private float _explosionRadius;

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
        Collider2D[] health = Physics2D.OverlapCircleAll(transform.position, _explosionRadius);
        foreach (Collider2D h in health)
        {
            if (h.TryGetComponent(out IHealth component))
                component.TakeDamage(_damage);
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _explosionRadius);
    }

}
