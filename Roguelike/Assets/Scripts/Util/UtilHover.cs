using UnityEngine;

[RequireComponent(typeof(Transform))]

public class UtilHover : MonoBehaviour {
  private GameObject go;
  private Transform goTf;
  private GameObject[] children;

  [Range(0.001f, 1f)] public float graphVelocity;
  [Range(1, 1000)] public int magnitude;

  private float cos;
  private const float magnitudeNormalize = 1000;

  private void Awake() {
    go = gameObject;
    goTf = go.transform;
  }

  private void Start() {
    cos = 0f;
  }

  private void Update() {
    cos += graphVelocity;
    goTf.Translate(Vector3.up * Mathf.Cos(cos) * magnitude/magnitudeNormalize, Space.World);
  }
}
