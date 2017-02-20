using UnityEngine;

[RequireComponent(typeof(Transform))]

public class PlayerMouseLook : MonoBehaviour {
  private Transform goTransform    ;
  private Transform cameraTransform;
  private Vector2   rotation       ;

  public float clampCeil        = -85f;
  public float clampFloor       =  85f;
  public float mouseSensitivity =   3f;

  private void Awake() {
    goTransform     = transform                    .GetComponent<Transform>();
    cameraTransform = transform.FindChild("Camera").GetComponent<Transform>();
  }

  private void Start() {

  }
}
