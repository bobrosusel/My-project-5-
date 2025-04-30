using System;
using UnityEngine;

public class Health : MonoBehaviour, IHealth
{
    [SerializeField] private float _health;

    public void TakeDamage(float damage)
    {
        _health = Math.Max(0, _health - damage);

        if (_health == 0)
        {
            Destroy(gameObject);
        }
    }
}
