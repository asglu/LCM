using UnityEngine;
using UnityEngine.UI;
using System.Collections;

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
	public Text pointText;
	public static float high = 20;
	private static int points;
	public Animator hunt;
	public GameObject splat;
	public GameObject bloodWater;
	public GameObject pakcam;
	public GameObject lonocam;
	public AudioSource local;
	public AudioSource haole;
	public AudioSource sole;

		
	void start ()
	{
		float h = -Input.GetAxis ("Horizontal");
		transform.Translate (h, 0, 0);
		bloodWater.gameObject.SetActive (false);
		splat.gameObject.SetActive (false);
		//hunter
		hunt = GetComponent<Animator> ();
		
	}//start

	void Update ()
	{
		high -= Time.deltaTime;
		SetHighText ();
		SetPointText ();
		
		if (high > 20) {
			//godmode
			hunt.SetBool ("fly", true);
			bloodWater.gameObject.SetActive (true);
			pakcam.gameObject.SetActive (false);
			lonocam.gameObject.SetActive (true);
		}//if
		
		if (high < 20) {
			//regularmode
			hunt.SetBool ("fly", false);
			bloodWater.gameObject.SetActive (false);
			pakcam.gameObject.SetActive (true);
			lonocam.gameObject.SetActive (false);
		}//if
		if (high < 0) {
			//regularmode
			Application.LoadLevel ("EndScreen");
			high = 20;
		}//if
		
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
	
	void OnTriggerEnter (Collider other)
	{
		//pickups
		if (other.gameObject.CompareTag ("drugs") && hunt.GetBool ("fly") == false) {
			other.gameObject.SetActive (false);
			high = high + 5;
			SetHighText ();
		}//if
		//pickups
		if (other.gameObject.CompareTag ("club") && hunt.GetBool ("fly") == false) {
			other.gameObject.SetActive (false);
			high = 70;
			SetHighText ();
		}//if
		//NPC
		if (other.gameObject.CompareTag ("haole") && hunt.GetBool ("fly") == false) {
			high = high - 5;
			SetHighText ();
			haole.Play ();
		}//if
		if (other.gameObject.CompareTag ("local") && hunt.GetBool ("fly") == false) {
			high = high - 5;
			SetHighText ();
			local.Play ();
		}//if
		//NPC
		if (other.gameObject.CompareTag ("sam") && hunt.GetBool ("fly") == false) {
			sole.Play ();
			high = high - 100;
			SetHighText ();

		}//if
		//godmode NPC
		if (other.gameObject.CompareTag ("haole") && hunt.GetBool ("fly") == true 
			|| other.gameObject.CompareTag ("haole") && hunt.GetBool ("close") == true) {
			//trigger splat animation
			splat.gameObject.SetActive (true);
			//trigger hit animation
			hunt.SetBool ("close", true);
			other.gameObject.SetActive (false);
			points = points + 5;
			SetPointText ();
		}//if
		//godmode NPC
		if (other.gameObject.CompareTag ("sam") && hunt.GetBool ("fly") == true 
			|| other.gameObject.CompareTag ("sam") && hunt.GetBool ("close") == true) {
			//trigger splat animation
			splat.gameObject.SetActive (true);
			//trigger hit animation
			hunt.SetBool ("close", true);
			other.gameObject.SetActive (false);
			points = points + 10;
			SetPointText ();
		}//if
		//godmode NPC
		if (other.gameObject.CompareTag ("local") && hunt.GetBool ("fly") == true 
			|| other.gameObject.CompareTag ("local") && hunt.GetBool ("close") == true) {
			//trigger splat animation
			splat.gameObject.SetActive (true);
			//trigger hit animation
			hunt.SetBool ("close", true);
			other.gameObject.SetActive (false);
			points = points + 5;
			SetPointText ();
		}//if
		else {
			splat.gameObject.SetActive (false);
			hunt.SetBool ("close", false);
		}
	}//OnTriggerEnter
	
	void OnTriggerExit (Collider other)
	{
		//godmode NPC
		if (!other.gameObject.CompareTag ("local") && hunt.GetBool ("fly") == true
			|| !other.gameObject.CompareTag ("local") && hunt.GetBool ("close") == true) {
			//trigger splat animation
			splat.gameObject.SetActive (false);
			hunt.SetBool ("close", false);
		}//if
		//godmode NPC
		if (!other.gameObject.CompareTag ("haole") && hunt.GetBool ("fly") == true
			|| !other.gameObject.CompareTag ("haole") && hunt.GetBool ("close") == true) {
			//trigger splat animation
			splat.gameObject.SetActive (false);
			hunt.SetBool ("close", false);
		}//if
		//godmode NPC
		if (!other.gameObject.CompareTag ("sam") && hunt.GetBool ("fly") == true 
			|| !other.gameObject.CompareTag ("sam") && hunt.GetBool ("close") == true) {
			//trigger splat animation
			splat.gameObject.SetActive (false);
			hunt.SetBool ("close", false);
		}//if
	}//OnTriggerExit
	
	void SetHighText ()
	{
		highText.text = "Highness: " + high.ToString ();
	}//SetHighText
	
	void SetPointText ()
	{
		pointText.text = "Killpoints: " + points.ToString ();
	}//SetPointText
	
}//class