using UnityEngine;

public class MobileInputProvider : MonoBehaviour
{
    private void Start()
    {
        bool isMobile = true; //Application.isMobilePlatform;
        FixedJoystick[] joystick = GetComponentsInChildren<FixedJoystick>();
        foreach (FixedJoystick joy in joystick) 
            joy.gameObject.SetActive(isMobile);
        
        InputCheker.Input.IsMobile = isMobile;
    }
}
