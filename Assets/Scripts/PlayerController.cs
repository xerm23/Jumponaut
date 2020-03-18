using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
	public float MoveSpeed;
	public float Jump;
	private Rigidbody2D myrigidbody;
//	private Collider2D myCollider;
	private Animator myAnimator;

	//provera da li je na platformi
	public Transform groundCheck;
	public bool Grounded;
	public LayerMask whatisground;
	public float groundCheckRadius;

	public float JumpTime;
	private float jumptimecounter;

	public float speedMultiplier;
	public float speedIncreaseMilestone;
	private float speedMilestoneCount;

	private bool lost;

	public PlatformGenerator PG;
	//zvukovi
	public AudioSource JumpSound;
	public AudioSource DeathSound;
	public AudioSource BackgroundMusic;

	// Use this for initialization
	void Start () {
		myrigidbody = GetComponent<Rigidbody2D> ();
	//	myCollider = GetComponent<Collider2D> ();
		myAnimator = GetComponent<Animator> ();
		jumptimecounter = JumpTime;
		speedMilestoneCount = speedIncreaseMilestone;
		lost = false;
	}
	
	// Update is called once per frame
	void Update () {
		Grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatisground);

		myrigidbody.velocity = new Vector2 (MoveSpeed, myrigidbody.velocity.y);
		if(Input.GetKeyDown(KeyCode.Space)|| Input.GetKeyDown(KeyCode.Mouse0)){
			if (Grounded) {
				myrigidbody.velocity = new Vector2 (myrigidbody.velocity.x, Jump);
				JumpSound.Play ();
			}
		}
		if(Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0)){
			if (jumptimecounter > 0) {
				myrigidbody.velocity = new Vector2(myrigidbody.velocity.x, Jump);
				jumptimecounter -= Time.deltaTime;
			}
		}
		if (Input.GetKeyUp (KeyCode.Space)|| Input.GetKeyUp(KeyCode.Mouse0)) {
			jumptimecounter = 0;
		}
		if (Grounded) {
			jumptimecounter = JumpTime;
		}

		//povecanje brzine

		if (transform.position.x > speedMilestoneCount) {
			speedMilestoneCount += speedIncreaseMilestone;

			speedIncreaseMilestone *= speedMultiplier;
			MoveSpeed = MoveSpeed * speedMultiplier;
			PG.distanceBetweenMin *= speedMultiplier;
			PG.distanceBetweenMax *= speedMultiplier;
		}

		myAnimator.SetFloat ("Speed", myrigidbody.velocity.x);
		myAnimator.SetBool ("Grounded", Grounded);
		if (lost) {
			SceneManager.LoadScene ("GameOver");
		}
	}

	IEnumerator OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.layer == 15) {
			BackgroundMusic.Stop ();
			DeathSound.Play ();
			yield return new WaitForSeconds (0.8f);
			lost = true;
		}
	}
}
