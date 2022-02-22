using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    [SerializeField] private Vector3 direction;
    [SerializeField] private float beltSpeed;
    [SerializeField] private List<GameObject> onBelt;
    [SerializeField] private Transform beltTargetPoint;

    private void Start() {
        direction = transform.forward;
    }

    private void FixedUpdate() {
        for (int i = 0; i < onBelt.Count; i++)
        {
            onBelt[i].GetComponent<Rigidbody>().velocity = beltSpeed * direction * Time.deltaTime;
        }
    }

    private void OnCollisionStay(Collision other) {
        if (onBelt.Contains(other.gameObject)) { return;}
        
        MoveableItem crate = other.gameObject.GetComponent<MoveableItem>();
        if (crate)
        {
            if (crate.hasCurrentBelt == false) {
                onBelt.Add(other.gameObject);
                crate.hasCurrentBelt = true;
            }
        }
    }

    private void OnCollisionExit(Collision other)
    {
        other.gameObject.GetComponent<MoveableItem>().hasCurrentBelt = false;
        onBelt.Remove(other.gameObject);
    }
}
