using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chute : MonoBehaviour
{
    [SerializeField] private Transform genSpotTransform;
    [SerializeField] private GameObject spawnPrefab;
    [SerializeField] private float spawnTime = 4f;
    [SerializeField] public bool isOn = false;

    private Coroutine thisCo;

    public void StartSpawnItemCo() {
        thisCo = StartCoroutine(spawnItemRoutine());
    }

    public void StopSpawnItemCo() {
        StopCoroutine(thisCo);
    }

    public IEnumerator spawnItemRoutine() {
        while (isOn) {
            Instantiate(spawnPrefab, genSpotTransform.position, spawnPrefab.transform.rotation);
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
