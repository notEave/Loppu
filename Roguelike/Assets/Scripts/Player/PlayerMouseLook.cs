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
    goTransform     = transform                          .GetComponent<Transform>();
    cameraTransform = transform.FindChild("CameraParent").GetComponent<Transform>();
  }

  private void Start() {
    rotation = new Vector2(
      ClampAxis(cameraTransform.rotation.eulerAngles.x, clampFloor, clampCeil),
                goTransform    .rotation.eulerAngles.y
    );
  }

  private void Update() {
    rotation.x = Mathf.Clamp(rotation.x - InputHandler.MouseY() * mouseSensitivity,
      clampCeil, clampFloor);
    rotation.y += InputHandler.MouseX() * mouseSensitivity;
    cameraTransform.localRotation = Quaternion.Euler(rotation.x, 0f, 0f);
    goTransform.rotation = Quaternion.Euler(0f, rotation.y, 0f);

  }

  private static float ClampAxis(float euler, float floor, float ceil) {
    if(euler > Mathf.Abs(Mathf.Min(floor, ceil))) 
      return euler - 360f;
    return euler;
  }
}
