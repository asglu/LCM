using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class huntRun : MonoBehaviour
{
	public KeyCode left = KeyCode.LeftArrow;
	public KeyCode right = KeyCode.RightArrow;
	public float leftSpeed = 500;
	public float rightSpeed = 500;
	private float rightX = 6.66f;
	private float leftX = -5.97f;
	private float increment;
	public Text highText;
	public static float high;
	private static int points;
	public Animator anim;
	public AudioClip otherClip;
	
	void start ()
	{
		high = 50;
		float h = -Input.GetAxis ("Horizontal");
		transform.Translate (h, 0, 0);
		anim = GetComponent<Animator> ();
		//AudioSource audio = GetComponent<AudioSource> ();
	}//start

	void Update ()
	{
		high = high - Time.deltaTime * 1;
		SetHighText ();

		//restricts X movement
		if (transform.position.x > rightX) {
			transform.position = new Vector3 (rightX, transform.position.y, transform.position.z);
		}//if
		else if (transform.position.x < leftX) {
			transform.position = new Vector3 (leftX, transform.position.y, transform.position.z);
		}//else if

		//movement
		if (Input.GetKey (KeyCode.LeftArrow)) {
			increment += (leftSpeed / 100) * Time.deltaTime;
			transform.position = Vector3.Lerp (transform.position, transform.position + Vector3.left, increment);
		}//if
		
		if (Input.GetKey (KeyCode.RightArrow)) {
			increment += (rightSpeed / 100) * Time.deltaTime;
			transform.position = Vector3.Lerp (transform.position, transform.position + Vector3.right, increment);

		}//if
	}//update

	void FixedUpdate ()
	{
		
		if (high > 50) {
			//godmode
			anim.SetBool ("fly", true);
			//change song
			//audio.Stop();
			//audio.Play();
			//change skybox
			
			//change water color	
		}//if
		
		if (high < 50) {
			//regularmode
			anim.SetBool ("fly", false);
		}//if
	}//FU

	void OnTriggerEnter (Collider other)
	{
		//pickups
		if (other.gameObject.CompareTag ("drugs") && anim.GetBool ("fly") == false) {
			other.gameObject.SetActive (false);
			high = high + 5;
			SetHighText ();
		}//if
		//pickups
		if (other.gameObject.CompareTag ("club") && anim.GetBool ("fly") == false) {
			other.gameObject.SetActive (false);
			high = 100;
			SetHighText ();
		}//if
		//NPC
		if (other.gameObject.CompareTag ("runner") && anim.GetBool ("fly") == false) {
			high = high - 5;
			SetHighText ();
		}//if
		//NPC
		if (other.gameObject.CompareTag ("sam") && anim.GetBool ("fly") == false) {
			high = high - 100;
			SetHighText ();
		}//if
		//godmode NPC
		if (other.gameObject.CompareTag ("runner") && anim.GetBool ("fly") == true) {
			anim.SetBool ("close", true);
			other.gameObject.SetActive (false);
			points = points + 5;
		}//if
		//godmode NPC
		if (other.gameObject.CompareTag ("sam") && anim.GetBool ("fly") == true) {
			anim.SetBool ("close", true);
			other.gameObject.SetActive (false);
			points = points + 10;
		}//if
	}//OnTriggerEnter

	void SetHighText ()
	{
		highText.text = "Highness: " + high.ToString ();
	}//SetHighText

}//class