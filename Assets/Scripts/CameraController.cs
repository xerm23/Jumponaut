using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public PlayerController thePlayer;

	private Vector3 lastPosition;
	private float DistanceToMove;

	// Use this for initialization
	void Start () {
		thePlayer = FindObjectOfType<PlayerController> ();
		lastPosition = thePlayer.transform.position;

	}
	
	// Update is called once per frame
	void Update () {
		DistanceToMove = thePlayer.transform.position.x - lastPosition.x;
		transform.position=new Vector3((transform.position.x+DistanceToMove), transform.position.y, transform.position.z);

		lastPosition = thePlayer.transform.position;
	}
}
