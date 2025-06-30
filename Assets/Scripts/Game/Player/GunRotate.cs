using UnityEngine;

public class GunRotate : MonoBehaviour
{
    [SerializeField] private float _rotateZone;

    private float _deadZone;

    private void Start()
    {
        _deadZone = _rotateZone / 2;
    }
    private void Rotate(Vector2 inputDirection)
    {
        if (Time.timeScale == 0)
            return;

        if (InputCheker.Input.IsMobile == false)
        {
            inputDirection = Camera.main.ScreenToWorldPoint(inputDirection);
            inputDirection -= (Vector2) transform.position;
        }

        float rotZ = Mathf.Atan2(inputDirection.y, inputDirection.x) * Mathf.Rad2Deg;

        if (rotZ <= _deadZone && rotZ >= -_deadZone)
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
    }

    private void OnEnable()
    {
        InputCheker.Input.Look += Rotate;
    }

    private void OnDisable()
    {
        InputCheker.Input.Look -= Rotate;
    }
}
