using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    [SerializeField] private Transform targetPoint;
    [SerializeField] private float beltSpeed = 2f;

    private void OnCollisionStay(Collision other) {
        other.transform.position = Vector3.MoveTowards(other.transform.position, targetPoint.position, beltSpeed * Time.deltaTime);
    }
}
