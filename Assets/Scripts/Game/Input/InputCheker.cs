using UnityEngine;
using UnityEngine.Events;

public class InputCheker
{
    public event UnityAction<Vector2> Move;
    public event UnityAction<Vector2> Look;
    public event UnityAction Shot;
    public event UnityAction Escape;

    private bool _isMobile;

    public bool IsMobile
    {
        set
        {
            _isMobile = value;
            Enable();
        }
        get { return _isMobile; }
    }

    private InputSystemAction _input;

    private static InputCheker _inputCheker;


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
    }

    private void Enable()
    {
        if (!_isMobile)
        {
            _input.Player.Enable();

            EnableLook();
            EnableMove();

            _input.Player.Attack.performed += ctx => Shot?.Invoke();
            _input.Player.Escape.performed += ctx => Escape?.Invoke();
        }
    }


    private void EnableMove()
    {
        _input.Player.Move.started += ctx => Move?.Invoke(ctx.ReadValue<Vector2>());
        _input.Player.Move.performed += ctx => Move?.Invoke(ctx.ReadValue<Vector2>());
        _input.Player.Move.canceled += ctx => Move?.Invoke(ctx.ReadValue<Vector2>());
    }

    private void EnableLook()
    {
        _input.Player.Look.started += ctx => Look?.Invoke(ctx.ReadValue<Vector2>());
        _input.Player.Look.performed += ctx => Look?.Invoke(ctx.ReadValue<Vector2>());
        _input.Player.Look.canceled += ctx => Look?.Invoke(ctx.ReadValue<Vector2>());
    }

    public void TriggerMove(Vector2 direction) => Move?.Invoke(direction);
    public void TriggerLook(Vector2 direction) => Look?.Invoke(direction);
    public void TriggerShot() => Shot?.Invoke();
    public void TriggerEscape() => Escape?.Invoke();

}
