int triWidth = 64;
int triHeight = round((float) ((triWidth/2)*Math.sqrt(3)));

void setup() {
  size(2048, 1536);
  background(0);
  stroke(255);
  strokeWeight(2);
} 

void draw() {
  if(mousePressed) {
    boolean up = true;
    boolean odd = true;
    for(int j = 0; j < height; j += triHeight) {
      for(int i = -triWidth; i < width + triWidth; i += triWidth/2) {
        setColor();
        if(odd) {
          tri(i, j, up);
        } else {
          tri(i - triWidth/2, j, up);
        }
        up = !up;
      }
      odd = !odd; 
    }
    save("triangles.png");
  }
}

void tri(int x, int y, boolean up) {
  if(up) {
    triangle(x, y + triHeight, x + triWidth, y + triHeight, x + triWidth/2, y);
  } else {
    triangle(x, y, x + triWidth, y, x + triWidth/2, y + triHeight);
  }
} 
void setColor() {
  if(random(0, 100) < 99) {
    fill(0);
  } else {
    fill(255);
  }
} 