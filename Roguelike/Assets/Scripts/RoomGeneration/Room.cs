using UnityEngine;

namespace RoomBuilder {
  class Room {
    private Floor f;
    private Wall w;
    private Roof r;

    public Room() {
    }

    // returning this for method chaining

    public Room GenerateFloor(int wmin, int wmax, int hmin, int hmax) {
      f = new Floor(wmin, wmax, hmin, hmax);
      return this;
    }

    public Room GenerateWall() {
      w = new Wall(f);
      return this;
    }

    public Room GenerateRoof() {
      r = new Roof(w);
      return this;
    }
  }
}