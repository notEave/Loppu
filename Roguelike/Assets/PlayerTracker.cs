using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracker : MonoBehaviour {
  private GameObject go;
  private GameObject player;
  private bool var;

  private void Awake() {
    go = gameObject;
    player = GameObject.Find("Player");
  }

  private void Start() {
    var = false;
  }

  private void FixedUpdate() {
    Vector3 direction = player.transform.position - go.transform.position;
    RaycastHit info;
    Physics.Raycast(go.transform.position, direction, out info);

    if(info.collider == player.GetComponent<CharacterController>() && info.distance < 25.0f) {
      var = true;
    } else {
      var = false;
    }
  }

  public bool playerVisible() {
    return var;
  }
}