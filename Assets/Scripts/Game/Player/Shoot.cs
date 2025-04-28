using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _shootDelay;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private GameObject _bullet;

    private float _tempDelay;
    private Transform _transform;

    private void Start()
    {
        _transform = GetComponent<Transform>();
    }

    private void Update()
    {
        Timer();
    }

    private void Timer()
    {
        _tempDelay -= Time.deltaTime;
        if (_tempDelay <= 0 && Input.GetMouseButton(0))
            Shot();
    }

    private void Shot()
    {
        Debug.Log(_transform.rotation);
        GameObject b = Instantiate(_bullet, _transform.position, transform.rotation);
        Debug.Log(b.transform.rotation);
        b.GetComponent<Bullet>().SetProperties(_bulletSpeed, _damage);
        _tempDelay = _shootDelay;
    }
}
