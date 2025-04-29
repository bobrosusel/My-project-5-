using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _shootDelay;
    [SerializeField] private float _bulletCount;
    [SerializeField] private GameObject _bullet;

    private float _tempDelay;
    private Transform _transform;

    private void Start()
    {
        _transform = GetComponent<Transform>();
    }

    private void Update()
    {
        if (_bulletCount > 0)
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
        _bulletCount--;
        GameObject b = Instantiate(_bullet, _transform.position + transform.right * 0.5f, transform.rotation);
        b.transform.Rotate(0, 0, _transform.rotation.z + 90);
        b.GetComponent<Bullet>().SetProperties(_damage);
        _tempDelay = _shootDelay;
    }
}
