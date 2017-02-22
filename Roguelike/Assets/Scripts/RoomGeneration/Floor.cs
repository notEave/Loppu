using UnityEngine;

namespace RoomBuilder {
  class Floor {
    private readonly int           width ;
    private readonly int           height;

    public  readonly GameObject[,] floor ;

    public Floor(int widthMin, int widthMax, int heightMin, int heightMax) {
      this.width  = Random.Range(widthMin , widthMax  + 1);
      this.height = Random.Range(heightMin, heightMax + 1);

      this.floor  = Floor .GenerateFloorArray(this.width, this.height);
    }

    private static GameObject[,] GenerateFloorArray(int width, int height) {
      GameObject[,] go = new GameObject[width, height];

      for(int i = 0; i < go.Length; i++) {
        int x = Mathf.FloorToInt(i/ go.GetLength(1)),
            y = i % go.GetLength(1);

        go[x, y] = GameObject.CreatePrimitive(PrimitiveType.Quad);
        go[x, y].transform.position = new Vector3(x, 0, y);
        go[x, y].transform.rotation = new Quaternion(1, 0, 0, 1);
      }
      return go;
    }
  }
}