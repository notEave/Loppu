using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMechanism : MonoBehaviour {
  private GameObject go;
  private GameObject player;
  private PlayerTracker pt;
  private float lastFire;
  private float cooldown = 1.0f;
  public GameObject bulletPrefab;

  private void Awake() {
    go = gameObject;
    pt = go.GetComponent<PlayerTracker>();
    player = GameObject.Find("Player");
  }

  private void Start() {
    lastFire = 0.0f;
  }

  private void FixedUpdate() {
    GameObject bullet;
    Vector3 force;
    if(Time.time - lastFire > cooldown && pt.playerVisible()) {
      lastFire = Time.time;
      bullet = Instantiate(bulletPrefab, go.transform.position + new Vector3(0, 1, 0), new Quaternion(), go.transform);
      force = player.transform.position - bullet.transform.position;
      bullet.transform.rotation = Quaternion.Euler(force);
      bullet.GetComponent<Rigidbody>().velocity = new Vector3(force.x * 2, 0.5f, force.z * 2);
    }
  }


}