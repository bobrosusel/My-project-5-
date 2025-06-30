using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickLook : MonoBehaviour, IPointerUpHandler
{
    private Joystick _joystick;

    private void Start()
    {
        _joystick = GetComponent<FixedJoystick>();
    }

    private void Update()
    {
        Vector2 lookInput = new Vector2(_joystick.Horizontal, _joystick.Vertical);
        if (lookInput.magnitude > 0.1f) 
        {
            InputCheker.Input.TriggerLook(lookInput);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        InputCheker.Input.TriggerShot();
    }

}
