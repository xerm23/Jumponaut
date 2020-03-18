using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {
	public GameObject Dijamant;
	public float DijamantspawnProcenat;

	public Transform generationPoint;
	public float distanceBetweenMin;
	public float distanceBetweenMax;
	public GameObject[] thePlatforms;

	private float distanceBetween;
	private int platformSelector;
	private float[] platformWidths;

	//promena y za platforme
	private float minHeight;
	public Transform maxHeightPoint;
	private float maxHeight;
	public float maxHeightChange;
	private float heightChange;


	// Use this for initialization
	void Start () {
		platformWidths = new float[thePlatforms.Length];	
		for (int i = 0; i < platformWidths.Length; i++) {
			platformWidths [i] = thePlatforms [i].GetComponent<BoxCollider2D> ().size.x;
		}
		minHeight = transform.position.y;
		maxHeight = maxHeightPoint.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < generationPoint.position.x) {
			distanceBetween = Random.Range (distanceBetweenMin, distanceBetweenMax);
			platformSelector = Random.Range (0, thePlatforms.Length);

			heightChange = transform.position.y + Random.Range (maxHeightChange, -maxHeightChange);
			if (heightChange > maxHeight) {
				heightChange = maxHeight;
			}
			if (heightChange < minHeight) {
				heightChange = minHeight;
			}
			//gde se stvara nova platforma
			transform.position = new Vector3 (transform.position.x+platformWidths[platformSelector]+distanceBetween,heightChange,transform.position.z);
			Instantiate (thePlatforms[platformSelector], transform.position, transform.rotation);





			//stvaranje dijamanata	
			Vector3 pozicijazadijamante = new Vector3 (transform.position.x, transform.position.y + 1f, transform.position.z);
	
			if (Random.Range (0f, 100f) < DijamantspawnProcenat) {
				Instantiate (Dijamant, pozicijazadijamante, transform.rotation);
				pozicijazadijamante.x -= 1;
				Instantiate (Dijamant, pozicijazadijamante, transform.rotation);
				pozicijazadijamante.x += 2;
				Instantiate (Dijamant, pozicijazadijamante, transform.rotation);
			}



		}
	}
}
