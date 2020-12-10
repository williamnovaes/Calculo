using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolinhaSpawner : MonoBehaviour {
    public GameObject bolinhaPrefab;
    public float xArea, yArea;
    public Sprite[] sprites;

    public void Spawn(int quantidade, bool isSoma = true) {
        int loop = isSoma ? Random.Range(quantidade + 4, quantidade + 8) : quantidade;

        for (int i = 0; i < loop; i++) {
            Vector3 spawnPosition = transform.position + new Vector3(Random.Range(-0.3f + xArea, 0.2f + xArea), Random.Range(-0.3f + yArea, 0.5f + yArea), 0f);
            GameObject obj = Instantiate(bolinhaPrefab, spawnPosition, Quaternion.identity) as GameObject;
            obj.GetComponent<DragDrop>().Initialize(sprites[Random.Range(0, sprites.Length)], isSoma);
        }
    }
}
