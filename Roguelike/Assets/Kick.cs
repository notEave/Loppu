using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kick : MonoBehaviour {
  private GameObject go;
  private float cooldown = 0.3f;
  private float lastShot;
  private float lastReturn;
  private Vector3 origin;
  private int shots;

  private void Awake() {
    go = gameObject;
    origin = go.transform.position;
    lastShot = 0.0f;
    lastReturn = 0;
    shots = 0;
  }

  private void Update() {
      Vector3 offset = new Vector3(0,0.05f,-0.1f);
    if(InputHandler.Hit() && Time.time - lastShot > cooldown) {
      lastShot = Time.time;
      go.transform.localPosition = go.transform.localPosition + offset;
      shots = 1;
    }

    if(shots == 1 && Time.time - lastShot > cooldown / 2) {
      shots = 0;
      go.transform.localPosition = go.transform.localPosition - offset;
    }
  }
}
