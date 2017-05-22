using UnityEngine;
using System.Collections.Generic;

using System;

public class Path : MonoBehaviour {
  private int width;
  private int height;
  public CellXArr c;
  public GameObject go;

  private void Awake() {

  }

  private void Start() {
    go = gameObject;
    width = FloorGeneration.lengthX;
    height = FloorGeneration.lengthZ;

    c = new CellXArr(width, height);
    c.traverse();
  }

  public void toDefault() {
    Start();
  }
}

public class CellXArr {
  public int width;
  public int height;

  private CellX[,] array;
  private CellX current;
  public Stack<CellX> st;
  private System.Random r;

  public CellXArr(int _width, int _height) {
    width = _width;
    height = _height;
    array = new CellX[width, height];
    st = new Stack<CellX>();
    r = new System.Random();
    init();
    current = array[0, 0];
    st.Push(current);
  }

  private void init() {
    int x, y;
    for(y = 0; y < height; y++) {
      for(x = 0; x < width; x++) {
        array[x, y] = new CellX(x, y, array, r);
      }
    }
  }

  public void traverse() {
    while(true) {
      current.traversed = true;

      if(current.pathsBlocked()) {
        if(current.x == 0 && current.y == 0) {
          return;
        } else {
          current = current.previous;
          continue;
        }
      }

      CellX next = current.next();
      next.previous = current;
      current = next;
      st.Push(current);
    }
  }

  public void print() {
    int x, y;
    for(y = 0; y < height; y++) {
      for(x = 0; x < width; x++) {
      }
    }
  }
}

public class CellX {
  public int x;
  public int y;
  public bool traversed;
  public CellX[,] cellarr;

  public static int TOP = 0;
  public static int RIGHT = 1;
  public static int BOTTOM = 2;
  public static int LEFT = 3;

  public bool wallLeft;
  public bool wallRight;
  public bool wallTop;
  public bool wallBottom;
  public CellX previous;
  private System.Random r;

  public CellX(int _x, int _y, CellX[,] _cellarr, System.Random r) {
    x = _x;
    y = _y;
    traversed = false;
    cellarr = _cellarr;
    this.r = r;
  }

  public CellX next() {
    int direction;
    while(true) {
      direction = r.Next(4);
      if(direction == TOP && topAvailable()) {
        return top();
      } else if(direction == RIGHT && rightAvailable()) {
        return right();
      } else if(direction == BOTTOM && bottomAvailable()) {
        return bottom();
      } else if(direction == LEFT && leftAvailable()) {
        return left();
      }
    }
  }

  public Direction previousDirection() {
    if(previous == null) {
      throw new System.Exception();
    }

    if(previous.x < x) {
      return Direction.WEST;
    } else if(previous.x > x) {
      return Direction.EAST;
    } else if(previous.y < y) {
      return Direction.SOUTH;
    } else if(previous.y > y) {
      return Direction.NORTH;
    }
    throw new System.Exception();
  }

  public bool leftAvailable() {
    int leftX = x - 1;
    if(leftX < 0) {
      return false;
    }
    return !cellarr[leftX, y].traversed;
  }

  public bool rightAvailable() {
    int rightX = x + 1;
    if(rightX >= cellarr.GetLength(0)) {
      return false;
    }
    return !cellarr[rightX, y].traversed;
  }


  public bool topAvailable() {
    int topY = y - 1;

    if(topY < 0) {
      return false;
    }

    return !cellarr[x, topY].traversed;
  }

  public bool bottomAvailable() {
    int bottomY = y + 1;
    if(bottomY >= cellarr.GetLength(1)) {
      return false;
    }

    return !cellarr[x, bottomY].traversed;
  }

  public CellX left() {
    return cellarr[x - 1, y];
  }

  public CellX right() {
    return cellarr[x + 1, y];
  }

  public CellX top() {
    return cellarr[x, y - 1];
  }

  public CellX bottom() {
    return cellarr[x, y + 1];
  }

  public char dirToPrev() {
    if(x == 0 && y == 0) {
      return 'x';
    }
    if(previous == null) {
      return 'o';
    }
    if(previous.x < x) {
      return '<';
    } else if(previous.x > x) {
      return '>';
    } else if(previous.y < y) {
      return '^';
    } else if(previous.y > y) {
      return 'v';
    }
    return '0';
  }


  public bool pathsBlocked() {
    return !leftAvailable() && !rightAvailable() && !topAvailable() && !bottomAvailable();
  }
}