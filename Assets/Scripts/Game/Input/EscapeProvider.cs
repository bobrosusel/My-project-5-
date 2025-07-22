using UnityEngine;

public class EscapeProvider : MonoBehaviour
{
    public void EscapeClick()
    {
        InputCheker.Input.TriggerEscape();
    }
}
