using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    [SerializeField] Texture2D cursorOpen;
    [SerializeField] Texture2D cursorClosed;
    [SerializeField] Texture2D cursorPointer;

    private void Awake() {
        ChangeCursor(cursorPointer);
        ToggleMouseOff();
    }

    private void ChangeCursor(Texture2D cursorType) {
        Vector2 hotspot = new Vector2(cursorType.width / 2, cursorType.height / 2);
        Cursor.SetCursor(cursorType, hotspot, CursorMode.Auto);
    }

    public void ToggleMouseOff() {
        Cursor.visible = false;
    }

    public void ToggleMouseOn() {
        Cursor.visible = true;
    }

    public void CursorOpenHand() {
        ChangeCursor(cursorOpen);
    }

    public void CursorClosedHand()
    {
        ChangeCursor(cursorClosed);
    }

    public void CursorPointerHand() {
        ChangeCursor(cursorPointer);
    }
}
