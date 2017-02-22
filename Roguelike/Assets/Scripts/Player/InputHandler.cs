using UnityEngine;

public class InputHandler {
  public static float StrafeAxis() { return Input.GetAxis("Horizontal"); }
  public static float WalkAxis  () { return Input.GetAxis("Vertical"  ); }

  public static float MouseX() { return Input.GetAxis("Mouse X"); }
  public static float MouseY() { return Input.GetAxis("Mouse Y"); }

  public static bool Hit      () { return Input.GetButtonDown("Hit"      ); }
  public static bool Block    () { return Input.GetButtonDown("Block"    ); }
  public static bool Magic    () { return Input.GetButtonDown("Magic"    ); }
  public static bool Activate () { return Input.GetButtonDown("Activate" ); }
  public static bool Jump     () { return Input.GetButtonDown("Jump"     ); }
  public static bool Inventory() { return Input.GetButtonDown("Inventory"); }
}