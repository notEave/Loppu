using UnityEngine;

public class FloorGeneration : MonoBehaviour {
  private GameObject go;
  private Transform goTf;
  private Cell[,] cells;
  public GameObject cellPrefab;

  public int lengthX;
  public int lengthZ;

  private void Awake() {
    go = gameObject;
    goTf = go.transform;
    cells = new Cell[lengthX, lengthZ];
  }

  private void Start() {
    int x,z;
    for(z = 0; z < lengthZ; z++) {
    for(x = 0; x < lengthX; x++) {
      Debug.Log("test");
      cells[x, z] = Instantiate(cellPrefab, new Vector3(x, 0, z), new Quaternion(0,0,0,0), goTf).GetComponent<Cell>();
    }}
  }
}