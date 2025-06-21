using System;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _shootDelay;
    [SerializeField] private float _bulletCount;
    [SerializeField] private GameObject _bullet;

    public event Action BulletOver;

    private float _tempDelay;
    private PlayerAnimator _animator;

    private GameObject _lastBullet;

    private void Start()
    {
        _animator = new PlayerAnimator(GetComponent<Animator>());
    }

    private void Update()
    {
        if (_bulletCount > 0 & Time.timeScale != 0)
            Timer();

        CheckBulletCount();
    }

    private void Timer()
    {
        _tempDelay -= Time.deltaTime;
        if (_tempDelay <= 0 && Input.GetMouseButton(0))
            Shot();
    }

    private void Shot()
    {
        _animator.SetShot();
        _tempDelay = _shootDelay;
    }

    [SerializeField]
    private void SpawnBullet()
    {
        _lastBullet = Instantiate(_bullet, transform.position + transform.right * 0.5f, transform.rotation);
        _lastBullet.transform.Rotate(0, 0, transform.rotation.z + 90);
        _lastBullet.GetComponent<Bullet>().SetProperties(_damage);
        _bulletCount--;
    }

    private void CheckBulletCount()
    {
        if (_bulletCount == 0 && _lastBullet == null)
            BulletOver.Invoke();
    }

}
