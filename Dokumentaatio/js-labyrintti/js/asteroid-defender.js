// jshint esversion:6, -W138

class Labyrinth {
  // labyrinth size is page width, and height / 5 floored
  /*
   * int width
   * int height
   */
  constructor(width, height) {
    this.width  = Math.floor(width  / 5);
    this.height = Math.floor(height / 5);
    this.tile = new Array(this.width);
    for(var i = 0; i < this.tile.length; i++)
      this.tile[i] = new Array(this.height);
    for(var i = 0; i < this.width * this.height; i++) {
      var x = Math.floor(i / this.height);
      var y = i % this.height;
      console.log(x,y);
    }

  }

  Physics() {
  }

  Draw() {

  }
}

class Square {
  constructor(rad, px, py) {
    this.radius = rad;
    this.x = px;
    this.y = py;
  }
  Draw() {

  }
}
