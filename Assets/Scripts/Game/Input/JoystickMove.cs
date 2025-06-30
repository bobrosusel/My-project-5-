using UnityEngine;

public class JoystickMove : MonoBehaviour
{
    private Joystick _joystick;

    private void Start()
    {
        _joystick = GetComponent<FixedJoystick>();
    }

    private void Update()
    {
        Vector2 moveInput = new Vector2(_joystick.Horizontal, _joystick.Vertical);
        InputCheker.Input.TriggerMove(moveInput);
    }
}
