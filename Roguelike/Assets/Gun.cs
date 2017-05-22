using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
  private GameObject player;
  private EnemyHandler enemies;

  private void Awake() {
    player = gameObject;
    enemies = GameObject.Find("EnemiesPrefab").GetComponent<EnemyHandler>();
  }

  private void Start() {

  }

  private void Update() {
    if(InputHandler.Hit()) {
      Debug.Log("HIT");
      RaycastHit info;
      GameObject enemy;
      Vector3 dir;
      Physics.Raycast(player.transform.position, player.transform.forward, out info);
      for(int i = 0; i < enemies.enemyArray().Length; i++) {
        if(info.collider.transform.root == enemies.enemyArray()[i].transform) {
          enemies.enemyArray()[i].SetActive(false);
        }
      }
    }
  }
}
