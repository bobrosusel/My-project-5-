using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _health;

    public void TakeDamage(float damage)
    {
        float health = Math.Max(0, _health - damage);
        if (health == 0)
        {
            Destroy(gameObject);
        }
    }
}
