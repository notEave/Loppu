using UnityEngine;

[RequireComponent(typeof(Transform))]

class UtilRotation : MonoBehaviour {
  private GameObject go;
  private Transform goTf;

  [Range(-1f, 1f)] public float rotationVelocity;

  private static readonly int rotationMultiplier = 100;

  private void Start() {
    go = gameObject;
    goTf = go.transform;
  }

  private void Update() {
    float zrot = rotationVelocity * rotationMultiplier * Time.deltaTime;
    goTf.Rotate(0, 0, zrot);
  }
}