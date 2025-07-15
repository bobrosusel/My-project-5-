using UnityEngine;

public class ArrowProvider : MonoBehaviour
{
    public void ButtonExit()
    {
        InputCheker.Input.TriggerMove(Vector2.zero);
    }

    public void ButtonUp()
    {
        InputCheker.Input.TriggerMove(new Vector2(0, 1));
    }

    public void ButtonDown()
    {
        InputCheker.Input.TriggerMove(new Vector2(0, -1));
    }
}
