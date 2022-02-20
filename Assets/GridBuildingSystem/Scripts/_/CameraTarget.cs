using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class CameraTarget : MonoBehaviour {

    public enum Axis {
        XZ,
        XY,
    }

    [SerializeField] private Axis axis = Axis.XZ;
    [SerializeField] private float moveSpeed = 50f;
    [SerializeField] private float zoomSpeed = 1f;


    private void Update() {
        float moveX = 0f;
        float moveY = 0f;
        float moveZ = 0f;

        if (Input.GetKey(KeyCode.W)) {
            moveZ = +1f;
        }
        if (Input.GetKey(KeyCode.S)) {
            moveZ = -1f;
        }
        if (Input.GetKey(KeyCode.A)) {
            moveX = -1f;
        }
        if (Input.GetKey(KeyCode.D)) {
            moveX = +1f;
        }
        if (Input.mouseScrollDelta.y > 0f)
        {
            moveY = -1f * zoomSpeed;
        }
        if (Input.mouseScrollDelta.y < 0f)
        {
            moveY = 1f * zoomSpeed;
        }
        

        Vector3 moveDir;


        switch (axis) {
            default:
            case Axis.XZ:
                if (moveY != 0) {
                    moveDir = new Vector3(moveX, moveY, moveZ);
                } else {
                    moveDir = new Vector3(moveX, moveY, moveZ).normalized;
                }
                break;
            case Axis.XY:
                moveDir = new Vector3(moveX, moveZ).normalized;
                break;
        }
        
        if (moveX != 0 || moveZ != 0) {
            // Not idle
        }

        if (axis == Axis.XZ) {
            moveDir = UtilsClass.ApplyRotationToVectorXZ(moveDir, 0);
        }

        transform.position += moveDir * moveSpeed * Time.deltaTime;
    }

}
