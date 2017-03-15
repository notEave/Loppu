using UnityEngine;

class Floor : MonoBehaviour {
  public int widthMin  = 11;
  public int widthMax  = 11;
  public int heightMin = 11;
  public int heightMax = 11;

  public GameObject floorPrefab;
  private GameObject go;
  private GameObject[,] floor;

  private void Start() {
    go = gameObject;

    this.floor = Floor.GenerateFloorArray(
      Random.Range(widthMin , widthMax  + 1),
      Random.Range(heightMin, heightMax + 1),
      floorPrefab,
      go.transform
    );
  }

  private static GameObject[,] GenerateFloorArray(int width, int height, GameObject prefab, Transform parent) {
    GameObject[,] go = new GameObject[width, height];

    for(int i = 0; i < go.Length; i++) {
      int x = Mathf.FloorToInt(i/ go.GetLength(1)),
          y = i % go.GetLength(1);

      go[x, y] = Instantiate(prefab,
        new Vector3(x, 0, y),
        new Quaternion(),
        parent
      );
      go[x, y].name = prefab.name;
    }
    return go;
  }

  public int Width() {
    return floor.GetLength(0);
  }

  public int Height() {
    return floor.GetLength(1);
  }
}