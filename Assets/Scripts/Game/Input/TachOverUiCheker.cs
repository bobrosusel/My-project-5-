using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TachOverUICheker : MonoBehaviour
{
    [SerializeField] private GraphicRaycaster _raycaster;

    private void Awake()
    {
        InputCheker.Input.TachOverUI = this;
    }

    public bool IsOverUI(Vector2 screenPos)
    {
        PointerEventData pointerData = new PointerEventData(EventSystem.current);
        pointerData.position = screenPos;

        List<RaycastResult> results = new List<RaycastResult>();
        _raycaster.Raycast(pointerData, results);

        return results.Count > 0;
    }

}
