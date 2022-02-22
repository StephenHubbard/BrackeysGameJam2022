using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    Vector3 offset;

    CursorController cursorController;
    [SerializeField] LayerMask groundMask = new LayerMask();

    private void Awake() {
        cursorController = FindObjectOfType<CursorController>();
    }

    void OnMouseDown()
    {
        offset = transform.position - MouseWorldPosition();
        // transform.GetComponent<Collider>().enabled = false;
        cursorController.CursorClosedHand();
    }

    void OnMouseDrag()
    {
        transform.position = MouseWorldPosition() + offset;
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        cursorController.CursorClosedHand();
    }

    private void OnMouseEnter() {
        cursorController.CursorOpenHand();
    }

    private void OnMouseExit() {
        cursorController.CursorPointerHand();    
    }

    void OnMouseUp()
    {
        var rayOrigin = Camera.main.transform.position;
        var rayDirection = MouseWorldPosition() - Camera.main.transform.position;
        RaycastHit hitInfo;
        if (Physics.Raycast(rayOrigin, rayDirection, out hitInfo, groundMask))
        {
            transform.position = hitInfo.transform.position;
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
    }
        // transform.GetComponent<Collider>().enabled = true;
        cursorController.CursorOpenHand();
    }

    Vector3 MouseWorldPosition()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }
}