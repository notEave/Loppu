using UnityEngine;

[RequireComponent(typeof(Transform          ))]
[RequireComponent(typeof(CharacterController))]

public class PlayerMovement : MonoBehaviour {
  private Transform           goTransform ;
  private CharacterController goController;

  private Vector3             velocity    ;

  public float dragAir      = 99f;
  public float dragGround   = 95f;
  public float velocityMax  =  5f;
  public float acceleration =  2f;
  public float impulseJump  =  5f;

  private void Awake() {
    goTransform  = transform.GetComponent          <Transform>();
    goController = transform.GetComponent<CharacterController>();
  }

  private void Start() {
    velocity = Vector3.zero;
  }

  private void Update() {
    velocity = AddPlayerInputToVelocity(velocity, goController, goTransform, impulseJump, acceleration);
    velocity = ClampHorizontalVelocity (velocity, velocityMax                                         );
    velocity = AddGravityToVelocity    (velocity, goController                                        );
               MovePlayer              (                                                              );
    velocity = ApplyDragToVelocity     (velocity, goController, dragAir, dragGround                   );
  }

  private static Vector3 AddPlayerInputToVelocity(Vector3 v, CharacterController cc, Transform t, float ij, float a) {
    if(cc.isGrounded) {
      v.x += t.forward.z * (InputHandler.StrafeAxis() * a);
      v.z += t.forward.z * (InputHandler.WalkAxis  () * a);
      v.y  = InputHandler.Jump() ? ij : 0f          ;
    }
    return v;
  }

  private static Vector3 ClampHorizontalVelocity(Vector3 v, float max) {
    Vector2 vc = Vector2.ClampMagnitude(new Vector2(v.x, v.z), max);
    return new Vector3(vc.x, v.y, vc.y);
  }

  private static Vector3 AddGravityToVelocity(Vector3 v, CharacterController cc) {
      v.y += Physics.gravity.y * Time.deltaTime;
    return v;
  }

  private void MovePlayer() {
    goController.Move(velocity * Time.deltaTime);
  }

  private static Vector3 ApplyDragToVelocity(Vector3 v, CharacterController cc, float da, float dg) {
    if(cc.isGrounded) {
      v.x *= dg / 100f;
      v.z *= dg / 100f;
    } else {
      v.x *= da / 100f;
      v.z *= da / 100f;
    }
    return v;
  }
}