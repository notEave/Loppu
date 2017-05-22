using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {
  public void teleportToEnd() {
    gameObject.transform.position = new Vector3(0, 18, 0);
  }
}
