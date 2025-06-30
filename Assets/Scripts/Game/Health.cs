using System;
using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IHealth
{
    [SerializeField] private float _health;

    private AudioSource _source;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _source = GetComponent<AudioSource>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float damage)
    {
        _health = Math.Max(0, _health - damage);

        if (_health == 0)
        {
            _source.Play();
            _spriteRenderer.enabled = false;
            StartCoroutine(DelayDestroy());
        }
    }

    private IEnumerator DelayDestroy()
    {
        yield return new WaitForSeconds(_source.clip.length);
        Destroy(gameObject);
    }
}
