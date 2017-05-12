using UnityEngine;

[RequireComponent(typeof(Renderer))]

public class UtilPerlin : MonoBehaviour {
  private GameObject go;
  private Renderer goRenderer;

  private Color[,] pixels2d;
  private Color[] pixels;

  private Texture2D t2d;

  public int resolution = 32;
  public int scale = 24;

  public Color color;
  [Range(0.9f, 1.1f)] public float hsvMult = 1.0f;
  [Range(0.0f, 3f)] public float emissionMult = 1.0f;

  private Color emission;

  private void Awake() {
    go = gameObject;
    goRenderer = go.GetComponent<Renderer>();
    goRenderer.material.EnableKeyword("_EMISSION");
  }

  private void Start() {
    Generate();
    Flatten();
    Colorize();

    t2d = new Texture2D(resolution, resolution);
    t2d.SetPixels(pixels);
    t2d.Apply();

    emission = new Color(emissionMult, emissionMult, emissionMult);

    goRenderer.material.mainTexture = t2d;
    goRenderer.material.SetTexture("_EmissionMap", t2d);
    goRenderer.material.SetColor("_EmissionColor", emission);
  }

  private void Generate() {
    pixels2d = new Color[resolution, resolution];

    float perlpoint;
    int x, y;
    for(y = 0; y < pixels2d.GetLength(1); y++) {
      for(x = 0; x < pixels2d.GetLength(0); x++) {
        perlpoint = Mathf.PerlinNoise((float)x / resolution * scale, (float)y / resolution * scale);
        pixels2d[x, y] = new Color(perlpoint, perlpoint, perlpoint);
      }
    }
  }

  private void Flatten() {
    pixels = new Color[pixels2d.GetLength(0) * pixels2d.GetLength(1)];

    int x, y;
    for(y = 0; y < pixels2d.GetLength(1); y++) {
      for(x = 0; x < pixels2d.GetLength(0); x++) {
        pixels[x * resolution + y] = pixels2d[x, y];
      }
    }
  }

  private void Colorize() {
    float h, s, v,
          ph, ps, pv;
    int i;

    Color.RGBToHSV(color , out h, out s, out v);
    for(i = 0; i < pixels.Length; i++) {
      Color.RGBToHSV(pixels[i], out ph, out ps, out pv);
      ph = h;
      ps = s;
      pv *= hsvMult;
      pixels[i] = Color.HSVToRGB(ph, ps, pv);
    }
  }
}
