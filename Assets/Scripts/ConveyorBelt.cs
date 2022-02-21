using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    [SerializeField] private Vector3 direction;
    [SerializeField] private float beltSpeed;
    [SerializeField] private List<GameObject> onBelt;

    private void Start() {
        direction = transform.forward;
    }

    private void FixedUpdate() {
        for (int i = 0; i < onBelt.Count; i++)
        {
            onBelt[i].GetComponent<Rigidbody>().velocity = beltSpeed * direction * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other) {
    if (other.GetComponent<MoveableItem>())
        {
            onBelt.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other) {
        onBelt.Remove(other.gameObject);
    }

    
}
