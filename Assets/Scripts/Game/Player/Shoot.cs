using System;
using System.Collections;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _shootDelay;
    [SerializeField] private float _bulletCount;
    [SerializeField] private GameObject _bullet;

    public event Action BulletOver;

    private bool _canShot = true;
    private PlayerAnimator _animator;
    private AudioSource _audioSource;

    private GameObject _lastBullet;

    private void Start()
    {
        _animator = new PlayerAnimator(GetComponent<Animator>());
        _audioSource = GetComponent<AudioSource>();
    }

    private void CheckPossibilityShot()
    {
        if (_bulletCount > 0 && _canShot)
            Shot();

        CheckBulletOver();
    }


    private void Shot()
    {
        _canShot = false;
        StartCoroutine(Timer());
        _animator.SetShot();
    }
    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(_shootDelay);
        _canShot = true;
    }

    [SerializeField]
    private void SpawnBullet()
    {
        _audioSource.Play();

        _lastBullet = Instantiate(_bullet, transform.position + transform.right * 0.5f, transform.rotation);
        _lastBullet.transform.Rotate(0, 0, transform.rotation.z + 90);
        _lastBullet.GetComponent<Bullet>().SetProperties(_damage);
        _bulletCount = Math.Max(0, _bulletCount - 1);
    }

    private void CheckBulletOver()
    {
        if (_bulletCount == 0 && _lastBullet == null)
            BulletOver.Invoke();
    }

    private void OnEnable()
    {
        InputCheker.Input.Shot += CheckPossibilityShot;
    }

    private void OnDisable()
    {
        InputCheker.Input.Shot -= CheckPossibilityShot;
    }

}
