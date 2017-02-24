using UnityEngine;

public class RoomGenerator : MonoBehaviour {
  private GameObject go;

  // prefabs
  // floors parent prefab
  public GameObject floor;
  // labyrinth parent prefab
  public GameObject labyrinth;
  public GameObject wall;
  public GameObject roof;

  private void Awake() {
    go = gameObject;
  }
  private void Start() {
    Instantiate(floor, go.transform).name = floor.name;
    Instantiate(labyrinth, go.transform).name = labyrinth.name;
  }
}