using UnityEngine;

public class depRoomBuilder : MonoBehaviour {

  public int widthMin  =   5,
             widthMax  =  10,
             heightMin =   5,
             heightMax =  10;

  private GameObject[,] a;

  // variable for Floor gameobject transform
  // room contains floor width, floor height
  // each tile contains: RoomTile script
  // tiles need to be children of floor gameobject

  private void Awake() {
  }

  private void Start() {
    a = GenerateFloorArray(widthMin, widthMax, heightMin, heightMax);
    for(int i = 0; i < a.Length; i++) {
      int x = Mathf.FloorToInt(i / a.GetLength(1)),
          y = i % a.GetLength(1);
      // seinien kannalta loopissa pitäisi tarkastaa:
      // onko tiili kulmassa? (0,0)(0,max)(max,0)(max,max)
      // mihin suuntaan seinä tulee
      a[x, y] = GameObject.CreatePrimitive(PrimitiveType.Quad);
      a[x, y].transform.position = new Vector3(x, 0, y);
      a[x, y].transform.rotation = new Quaternion(1, 0, 0, 1);
    }    
  }

  private static GameObject[,] GenerateFloorArray(int wmin, int wmax, int hmin, int hmax) {
    return new GameObject[Random.Range(wmin, wmax + 1), Random.Range(hmin, hmax + 1)];
  }
}
