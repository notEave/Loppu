using UnityEngine;

[RequireComponent(typeof(Renderer))]

public class UtilMaterialRandomize : MonoBehaviour {

  private GameObject go     ;
  private Renderer   goRen  ;
  private Material   goMat  ;
  private Color      goColor;

  private const float min = 0.1f;
  private const float max = 1.0f;

  private void Awake() {
    go      = gameObject                    ;
    goRen   = go   .GetComponent<Renderer>();
    goMat   = goRen.material                ;
    goColor = goMat.color                   ;
  }

  private void Start() {
    float r, g, b, a;
    r = Random.Range(min, max);
    g = Random.Range(min, max);
    b = Random.Range(min, max);
    a = goColor.a;

    Color color = new Color(r, g, b, a);
    goMat.SetColor("_Color", color);
  }
}