using UnityEngine;

public class FloorGeneration : MonoBehaviour {
  private GameObject go;
  private Transform goTf;
  private Cell[,] cells;
  public GameObject cellPrefab;
  public GameObject endCellPrefab;

  public static int lengthX = 1;
  public static int lengthZ = 1;
  public float xzScale = 1.0f;
  public float yScale = 1.0f;
  public bool generated;

  private void Awake() {
    go = gameObject;
    goTf = go.transform;
    generated = false;
    cells = new Cell[lengthX, lengthZ];
  }

  private void Start() {
    int x,z;
    for(z = 0; z < lengthZ; z++) {
    for(x = 0; x < lengthX; x++) {
      if(x == lengthX -1 && z == lengthZ-1) {
        cells[x, z] = Instantiate(endCellPrefab, new Vector3(x * xzScale, 0, z * xzScale), new Quaternion(0, 0, 0, 0), goTf).GetComponent<Cell>();
        cells[x, z].transform.localScale = new Vector3(xzScale, yScale, xzScale);
        cells[x, z].name = endCellPrefab.name;
      } else {
        cells[x, z] = Instantiate(cellPrefab, new Vector3(x * xzScale, 0, z * xzScale), new Quaternion(0,0,0,0), goTf).GetComponent<Cell>();
        cells[x, z].transform.localScale = new Vector3(xzScale, yScale, xzScale);
        cells[x, z].name = cellPrefab.name;
        generated = true;
      }
    }}
    addFloor();
  }

  public void addFloor() {
    go.AddComponent<Floor>();
  }

  public void removeFloor() {
    Destroy(go.GetComponent<Floor>());
  }
  public Cell[,] getCells() {
    return cells;
  }

  public void toDefault() {
  }

  private void Reset() {
  }
}