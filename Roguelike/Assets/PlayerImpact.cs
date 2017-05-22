using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerImpact : MonoBehaviour {
  private GameObject player;

  private void Awake() {
    player = GameObject.Find("Player");
  }

  private void Start() {

  }

  private void FixedUpdate() {

  }

  private void OnCollisionEnter(Collision collision) {
    if(collision.transform == player.transform) {
      player.GetComponent<Teleport>().teleportToEnd();
    } else {
      Destroy(gameObject);
    }
  }
}
