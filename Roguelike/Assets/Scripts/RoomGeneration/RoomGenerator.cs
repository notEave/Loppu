using UnityEngine;

public class RoomGenerator : MonoBehaviour {
  private GameObject go;

  // prefabs
  public GameObject floor;
  public GameObject wall;
  public GameObject roof;

  private void Awake() {
    go = gameObject;
  }
  private void Start() {
    Instantiate(floor, go.transform);
  }
}