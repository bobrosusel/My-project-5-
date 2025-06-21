using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IHealth
{
    [SerializeField] private float _health;

    public event Action PlayerDeath;

    private PlayerAnimator _animator;

    private void Start()
    {
        _animator = new PlayerAnimator(GetComponent<Animator>());
    }
    public void TakeDamage(float damage)
    {
        _health = Mathf.Max(0, _health - damage);

        if (_health == 0)
        {
            _animator.SetDeath();
        }
    }

    [SerializeField]
    private void Death()
    {
        PlayerDeath.Invoke();
        Destroy(gameObject);
    }
}
