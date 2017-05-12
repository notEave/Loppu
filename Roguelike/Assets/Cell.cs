using UnityEngine;

public class Cell : MonoBehaviour {
  private GameObject go;
  private Transform goTf;
  public GameObject floorPrefab;
  public GameObject wallPrefab;
  
  private GameObject floor;

  private GameObject[] wall;

  private static readonly int NORTH = 0;
  private static readonly int EAST = 1;
  private static readonly int SOUTH = 2;
  private static readonly int WEST = 3;

  private void Awake() {
    go = gameObject;
    goTf = go.transform;
    wall = new GameObject[4];
  }

  private void Start() {
    floor = Instantiate(floorPrefab, new Vector3(0,0,0), Quaternion.Euler(90f, 0f, 0f), goTf);

    wall[NORTH] = Instantiate(wallPrefab, new Vector3(0, 1, 0.5f), Quaternion.Euler(0, 0, 0), goTf);
    wall[EAST]  = Instantiate(wallPrefab, new Vector3(0.5f, 1, 0), Quaternion.Euler(0, 90, 0), goTf);
    wall[SOUTH] = Instantiate(wallPrefab, new Vector3(0, 1, -0.5f), Quaternion.Euler(0, 180, 0), goTf);
    wall[WEST]  = Instantiate(wallPrefab, new Vector3(-0.5f, 1, 0), Quaternion.Euler(0, 270, 0), goTf);

    floor.name = "floor";
    wall[NORTH].name = "north";
    wall[EAST].name =  "east" ;
    wall[SOUTH].name = "south";
    wall[WEST].name =  "west" ;
  }

  public void deactivate(Direction direction) {
    switch(direction) {
    case Direction.NORTH: wall[NORTH].SetActive(false); break;
    case Direction.EAST : wall[EAST] .SetActive(false); break;
    case Direction.SOUTH: wall[SOUTH].SetActive(false); break;
    case Direction.WEST : wall[WEST] .SetActive(false); break;
    }
  }

  public void activate(Direction direction) {
    switch(direction) {
    case Direction.NORTH: wall[NORTH].SetActive(true); break;
    case Direction.EAST:  wall[EAST] .SetActive(true); break;
    case Direction.SOUTH: wall[SOUTH].SetActive(true); break;
    case Direction.WEST:  wall[WEST] .SetActive(true); break;
    }
  }

  public void flip(Direction direction) {
    switch(direction) {
    case Direction.NORTH: wall[NORTH].SetActive(!isActive(Direction.NORTH)); break;
    case Direction.EAST : wall[EAST] .SetActive(!isActive(Direction.EAST )); break;
    case Direction.SOUTH: wall[SOUTH].SetActive(!isActive(Direction.SOUTH)); break;
    case Direction.WEST : wall[WEST] .SetActive(!isActive(Direction.WEST )); break;
    }
  }

  public bool isActive(Direction direction) {
    switch(direction) {
    case Direction.NORTH: return wall[NORTH].activeSelf;
    case Direction.EAST : return wall[EAST] .activeSelf;
    case Direction.SOUTH: return wall[SOUTH].activeSelf;
    case Direction.WEST : return wall[WEST] .activeSelf;
    }
    return false;
  }

  private void Update() {

  }
}