using UnityEngine;

public class Cell : MonoBehaviour {
  private GameObject go;
  private Transform goTf;
  public GameObject floorPrefab;
  public GameObject wallPrefab;
  public GameObject endWallPrefab;
  private GameObject player;
  
  private GameObject floor;

  private GameObject[] wall;

  private static readonly int NORTH = 0;
  private static readonly int EAST  = 1;
  private static readonly int SOUTH = 2;
  private static readonly int WEST  = 3;

  private void Awake() {
    go = gameObject;
    player = GameObject.Find("Player");
    goTf = go.transform;
    wall = new GameObject[4];
  }

  private void Start() {
    Vector3 parent = goTf.position;
    Vector3 parentScale = goTf.localScale;
    float x, y, z;
    x = parentScale.x;
    y = parentScale.y;
    z = parentScale.z;

    floor = Instantiate(floorPrefab, parent + new Vector3(0,0,0), Quaternion.Euler(90f, 0f, 0f), goTf);
    if(endWallPrefab != null) {
      wall[NORTH] = Instantiate(endWallPrefab, parent + new Vector3(0 * x, 1 * y, 0.5f * z), Quaternion.Euler(0, 0, 0), goTf);
    } else {
    wall[NORTH] = Instantiate(wallPrefab, parent + new Vector3(0*x,1*y,0.5f*z), Quaternion.Euler(0, 0, 0  ), goTf);
    }
    wall[EAST]  = Instantiate(wallPrefab, parent + new Vector3(0.5f*x,1*y, 0*z), Quaternion.Euler(0, 90, 0 ), goTf);
    wall[SOUTH] = Instantiate(wallPrefab, parent + new Vector3(0*x,1*y,-0.5f*z), Quaternion.Euler(0, 180, 0), goTf);
    wall[WEST]  = Instantiate(wallPrefab, parent + new Vector3(-0.5f*x,1*y,0*z), Quaternion.Euler(0, 270, 0), goTf);
    
    floor.name = "floor";
    wall[NORTH].name = "north";
    wall[EAST].name =  "east" ;
    wall[SOUTH].name = "south";
    wall[WEST].name =  "west" ;
  }

  public void open(Direction direction) {
    switch(direction) {
    case Direction.NORTH: wall[NORTH].SetActive(false); break;
    case Direction.EAST : wall[EAST] .SetActive(false); break;
    case Direction.SOUTH: wall[SOUTH].SetActive(false); break;
    case Direction.WEST : wall[WEST] .SetActive(false); break;
    }
  }

  public void close(Direction direction) {
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

  private void FixedUpdate() {
    Renderer floorR = floor.GetComponent<Renderer>();

    Renderer wallNR = wall[NORTH].GetComponent<Renderer>();
    Renderer wallER = wall[EAST].GetComponent<Renderer>();
    Renderer wallSR = wall[SOUTH].GetComponent<Renderer>();
    Renderer wallWR = wall[WEST].GetComponent<Renderer>();

    Vector3 positionPlayer = player.transform.position;
    Vector3 positionSelf = goTf.position;
    if(Vector3.Distance(positionPlayer, positionSelf) > 30.0f) {
      floorR.enabled = false;
      wallNR.enabled = false;
      wallER.enabled = false;
      wallSR.enabled = false;
      wallWR.enabled = false;
    } else {
      floorR.enabled = true;
      wallNR.enabled = true;
      wallER.enabled = true;
      wallSR.enabled = true;
      wallWR.enabled = true;
    }
  }

  private void Update() {

  }
}