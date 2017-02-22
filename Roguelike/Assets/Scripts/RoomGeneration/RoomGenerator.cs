using UnityEngine;
using RoomBuilder;

  // Unity component script,
  // its a parent containing object instances
  // of all room specific classes

public class RoomGenerator : MonoBehaviour {
  public int widthMin  = 10,
             widthMax  = 10,
             heightMin = 10,
             heightMax = 10;

  private Room room;

  private void Start() {
    room = new Room()
      .GenerateFloor(widthMin, widthMax, heightMin, heightMax)
      .GenerateWall()
      .GenerateRoof();
  }

  // use OnEnterDoor to generate a new Random Room

  void OnEnterDoor() {
    this.Start();
  }
}