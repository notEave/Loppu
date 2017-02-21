using UnityEngine;

public class RoomBuilder : MonoBehaviour {
  public int width  = 20;
  public int height = 10;

  private GameObject[] a;

  private void Awake() {
    GameObject.CreatePrimitive(PrimitiveType.Quad);
  }

  private void Start() {
    a = new GameObject[width * height];

  }
}