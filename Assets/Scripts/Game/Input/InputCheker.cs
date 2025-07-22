using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.InputSystem.LowLevel;

public class InputCheker
{
    public event UnityAction<Vector2> Move;
    public event UnityAction<Vector2> Look;
    public event UnityAction Shot;
    public event UnityAction Escape;

    private InputSystemAction _input;

    private static InputCheker _inputCheker;

    public TachOverUICheker TachOverUI;

    public static InputCheker Input
    {
        get
        {
            if (_inputCheker == null)
                _inputCheker = new InputCheker();
            
            
            return _inputCheker ;
        }
    }


    private InputCheker() 
    {
        _input = new InputSystemAction();
        EnhancedTouchSupport.Enable();
        Enable();
    }

    public void Enable()
    {
        _input.Player.Enable();
        _input.Player.Interact.performed += InteractEnable;
    }

    private void InteractEnable(InputAction.CallbackContext context)
    {
        if (TachOverUI != null && !TachOverUI.IsOverUI(context.ReadValue<Vector2>()))
            Look?.Invoke(context.ReadValue<Vector2>());
    }

    public void TriggerMove(Vector2 direction) => Move?.Invoke(direction);
    public void TriggerShot() => Shot?.Invoke();
    public void TriggerEscape() => Escape?.Invoke();

    public void RestartTouchScreen()
    {
        foreach (var touch in UnityEngine.InputSystem.EnhancedTouch.Touch.activeTouches)
        {
            InputSystem.QueueStateEvent(
                Touchscreen.current,
                new TouchState
                {
                    touchId = touch.touchId,
                    phase = UnityEngine.InputSystem.TouchPhase.Ended,
                    position = touch.screenPosition
                }
            );
        }
        InputSystem.Update();
    }

}
