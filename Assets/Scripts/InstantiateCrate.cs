using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class InstantiateCrate : MonoBehaviour
{
    [SerializeField] private GameObject cratePrefab;
    [SerializeField] private bool isOn = true;

    private void Update() {
        if (!isOn) {return;}

        if (Input.GetKeyDown(KeyCode.Space)) {
            Instantiate(cratePrefab, Mouse3D.GetMouseWorldPosition() + new Vector3(0, 5f, 0), transform.rotation);
        }
    }
}
