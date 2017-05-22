using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandler : MonoBehaviour {
  private GameObject go;
  private FloorGeneration fg;
  private GameObject[] enemies;
  public GameObject enemyPrefab;

  public GameObject[] enemyArray() {
    return enemies;
  }

  private void Awake() {
    go = gameObject;
    fg = GameObject.Find("Floor(Clone)").GetComponent<FloorGeneration>();
  }

  private void Start() {
    populate();
  }

  public void populate() {
    int x, z;
    int maxX, maxZ;
    float scale = fg.xzScale;
    maxX = FloorGeneration.lengthX;
    maxZ = FloorGeneration.lengthZ;
    enemies = new GameObject[maxX];

    for(int i = 0; i < maxX; i++) {
      x = Mathf.FloorToInt(Random.Range(1, maxX));
      z = Mathf.FloorToInt(Random.Range(1, maxX));
      enemies[i] = Instantiate(enemyPrefab, new Vector3(x * scale, 2, z * scale), new Quaternion());
      enemies[i].name = "enemy" + i;
      if(enemies[i].transform.position.x < 5 && enemies[i].transform.position.z < 5) {
        enemies[i].SetActive(false);
      }
    }
  }

  public void destroyAll() {
    foreach(GameObject enemy in enemies) {
      Destroy(enemy);
    }
  }
}
