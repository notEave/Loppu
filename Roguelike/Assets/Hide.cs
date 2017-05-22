using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour {
  private GameObject player;
  private GameObject go;
  private MeshRenderer mr;
	// Use this for initialization
	void Awake () {
		go = gameObject;
    mr = go.GetComponent<MeshRenderer>();
    player = GameObject.Find("Player");
	}

  private void FixedUpdate() {
    if(Vector3.Distance(go.transform.position, player.transform.position) > 10.0f) {
      mr.enabled = false;
    } else {
      mr.enabled = true;
    }
  }
}
