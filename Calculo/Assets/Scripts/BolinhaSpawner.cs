using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolinhaSpawner : MonoBehaviour {

    public GameObject bolinhaPrefab;
    public float xArea, yArea;

    public void Spawn(int quantidade) {
        for (int i = 0; i < Random.Range(quantidade + 1, quantidade + 5); i++) {
            Vector3 spawnPosition = transform.position + new Vector3(Random.Range(-0.5f + xArea, 0.5f + xArea), Random.Range(-0.5f + yArea, 0.5f + yArea), 0f);
            Instantiate(bolinhaPrefab, spawnPosition, Quaternion.identity);
        }
    }
   
}
