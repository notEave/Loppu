using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilChest : MonoBehaviour {
  private GameObject go;
  private Animation ani;
  private bool play;

  private void Awake() {
    go = gameObject;
    ani = go.GetComponentInChildren<Animation>();
    play = false;
  }

  private void Start() {
    /*foreach(AnimationState state in ani) {
      state.speed = 1.0f;
    }*/
  }

  private void Update() {
    /*
    if(InputHandler.Hit() && !play) {
      play = true;
      ani.Play();
    }
    */
  }
}