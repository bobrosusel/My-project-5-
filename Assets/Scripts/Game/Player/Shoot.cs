using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _shootDelay;
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
        Instantiate(_bullet, _transform.position, Quaternion.Euler(0, 0, GetAngale()));
        _tempDelay = _shootDelay;
    }

    private Vector3 GetCursorPosition()
    {
        Vector3 cursorWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cursorWorldPos.z = 0;
        return cursorWorldPos;
    }

    private float GetAngale()
    {
        Vector3 direction = GetCursorPosition() - _transform.position;
        return Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    }
}
