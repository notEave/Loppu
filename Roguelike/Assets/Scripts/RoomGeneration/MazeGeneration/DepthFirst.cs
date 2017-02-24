using UnityEngine;

public class DepthFirst : MonoBehaviour {
  public GameObject wallPrefab;
  public string floorName;

  private GameObject go;
  private Floor floor;

  private Point start;

  private GameObject[,] obstacle;
  private enum direction { north = 0, east, south, west };

  private void Awake() {
    go = gameObject;

    floor = go.transform.parent.Find(floorName).GetComponent<Floor>();
  }

  private void Start() {
    obstacle = new GameObject[floor.Width(), floor.Height()];
    PopulateArray();
  }

  private void PopulateArray() {
    for(int i = 0, x, y; i < obstacle.Length; i++) {
      x = Mathf.FloorToInt(i/obstacle.GetLength(1));
      y = i % obstacle.GetLength(1);

      obstacle[x, y] = Instantiate(wallPrefab,
        new Vector3(x, 0, y),
        new Quaternion(),
        go.transform
      );
      obstacle[x, y].name =  wallPrefab.name;
    }
  }

  private struct Point {
    private bool[] wall;
    public Point(int direction) {
      wall = new bool[4];
      wall[direction] = true;
    }

    private void AddWall(int direction) {
      wall[direction] = true;
    }

    private void RemoveWall(int direction) {
      wall[direction] = false;
    }

    private void FlipWall(int direction) {
      wall[direction] = !wall[direction];
    }
  }
}