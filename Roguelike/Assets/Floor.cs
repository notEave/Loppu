using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(FloorGeneration))]
[RequireComponent(typeof(Path))]

public class Floor : MonoBehaviour {
  private GameObject go;
  private FloorGeneration fg;
  private Path p;
  private Cell[,] cells;
  private Stack<CellX> stack;

  private void Awake() {
    go = gameObject;
    fg = go.GetComponent<FloorGeneration>();
    cells  = fg.getCells();
    p = go.GetComponent<Path>();
    stack = p.c.st;
  }

  private void Start() {
    CellX c;
    while(stack.Count > 0) {
      c = stack.Pop();
      try {
        get(c.x, c.y).open(c.previousDirection());
        get(c.previous.x, c.previous.y).open(opposite(c.previousDirection()));
      } catch(System.Exception e) {
        return;
      }
    }
  }

  public void open(int x, int y, Direction dir) {
    Cell self, other;
    int ox = x + dirCoord(dir)[0];
    int oy = y + dirCoord(dir)[1];

    self = get(x, y);
    other = get(ox, oy);
    try {
      self.open(dir);
      other.open(opposite(dir));
    } catch(System.Exception e) { }
  }

  public int[] dirCoord(Direction d) {
    switch(d) {
      case Direction.NORTH:
        return new int[] { 0, 1 };
      case Direction.SOUTH:
        return new int[] { 0, -1 };
      case Direction.WEST:
        return new int[] { -1, 0 };
      case Direction.EAST:
        return new int[] { 1, 0 };
      default:
        return null;
    }
  }

  public Direction opposite(Direction d) {
    switch(d) {
      case Direction.NORTH:
        return Direction.SOUTH;
      case Direction.SOUTH:
        return Direction.NORTH;
      case Direction.WEST:
        return Direction.EAST;
      case Direction.EAST:
        return Direction.WEST;
      default:
        return d;
    }
  }

  public Cell get(int x, int y) {
    try {
      return cells[x, y];
    } catch(System.Exception e) {
      return null;
    }
  }
}

/*using UnityEngine;

[RequireComponent(typeof(FloorGeneration))]

public class Floor : MonoBehaviour {
  private GameObject go;
  private Cell[,] cells;

  private void Awake() {
    go = gameObject;
    cells = go.GetComponent<FloorGeneration>().getCells();
  }

  private void Start() {
    int x, y;

    for(int i = 0; i < cells.GetLength(0) * 10; i++) {
      x = Mathf.FloorToInt(Random.Range(0, cells.GetLength(0) - 1));
      y = Mathf.FloorToInt(Random.Range(0, cells.GetLength(1) - 1));
      switch(Mathf.FloorToInt(Random.Range(0, 3))) {
        case 0:
          open(x, y, Direction.NORTH);
          break;
        case 1:
          open(x, y, Direction.EAST);
          break;
        case 2:
          open(x, y, Direction.WEST);
          break;
        case 3:
          open(x, y, Direction.SOUTH);
          break;
      }
    }
  }

  public void open(int x, int y, Direction dir) {
    Cell self, other;
    int ox = x + dirCoord(dir)[0];
    int oy = y + dirCoord(dir)[1];

    self = get(x, y);
    other = get(ox, oy);
    try {
      self.open(dir);
      other.open(opposite(dir));
    } catch(System.Exception e) {}
  }

  public void close(int x, int y, Direction dir) {
    Cell self, other;
    int ox = x + dirCoord(dir)[0];
    int oy = y + dirCoord(dir)[1];

    self = get(x, y);
    other = get(ox, oy);

    self.close(dir);
    other.close(dir);
  }

  public Cell get(int x, int y) {
    try {
      return cells[x, y];
    } catch(System.Exception e) {
      return null;
    }
  }

  public int[] dirCoord(Direction d) {
    switch(d) {
      case Direction.NORTH:
        return new int[] { 0, 1 };
      case Direction.SOUTH:
        return new int[] { 0, -1 };
      case Direction.WEST:
        return new int[] { -1, 0 };
      case Direction.EAST:
        return new int[] { 1, 0 };
      default:
        return null;
    }
  }

  public Direction opposite(Direction d) {
    switch(d) {
      case Direction.NORTH:
        return Direction.SOUTH;
      case Direction.SOUTH:
        return Direction.NORTH;
      case Direction.WEST:
        return Direction.EAST;
      case Direction.EAST:
        return Direction.WEST;
      default: return d;
    }
  }
}
*/