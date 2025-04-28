using UnityEngine;

public class GunRotate : MonoBehaviour
{
    [SerializeField] private float _rotateZone;

    private float _deadZone;

    private void Start()
    {
        _deadZone = _rotateZone / 2;
    }
    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();

        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        if (rotZ <= _deadZone && rotZ >= -_deadZone)
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
    }
}
