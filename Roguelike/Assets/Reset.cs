using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour {
  private GameObject go;
  private Transform goTf;
  private GameObject player;
  private GameObject labyrinth;
  private FloorGeneration fg;
  private Path p;
  public GameObject floor;
  public GameObject enemyPrefab;

	void Start () {
    go = gameObject;
    goTf = go.transform;
		player = GameObject.Find("Player");
    labyrinth = GameObject.Find("Floor");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

  private void FixedUpdate() {
    if(Vector3.Distance(player.transform.position, goTf.position) < 2.0f) {
      player.transform.position = new Vector3(0f,2.0f,0f);

      FloorGeneration.lengthX += 1;
      FloorGeneration.lengthZ += 1;

      Instantiate(floor);

      GameObject.Find("EnemiesPrefab").GetComponent<EnemyHandler>().destroyAll();

      GameObject.Find("EnemiesPrefab").GetComponent<EnemyHandler>().populate();

      Destroy(GameObject.Find("Floor(Clone)"));
    }
  }
}
