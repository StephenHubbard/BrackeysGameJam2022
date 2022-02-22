using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffButton : MonoBehaviour
{
    [SerializeField] private Chute thisChute;
    [SerializeField] private GameObject redButton;
    [SerializeField] private GameObject greenButton;

    public void ToggleChute() {
        if (thisChute.isOn == false) {
            thisChute.isOn = true;
            greenButton.SetActive(true);
            redButton.SetActive(false);
            thisChute.StartSpawnItemCo();
        } else if (thisChute.isOn == true) {
            thisChute.isOn = false;
            redButton.SetActive(true);
            greenButton.SetActive(false);
            thisChute.StopSpawnItemCo();
        }
    }

    void OnMouseDown() {
        ToggleChute();
    }
}
