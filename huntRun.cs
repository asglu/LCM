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
	public Text pointText;
	public static float high;
	private static int points;
	public Animator hunt;
	public GameObject spray;
	public GameObject bloodWater;
	public GameObject pakalolo;
	public GameObject clash;

	
	void start ()
	{
		high = 50;
		float h = -Input.GetAxis ("Horizontal");
		transform.Translate (h, 0, 0);
		spray.gameObject.SetActive (false);
		bloodWater.gameObject.SetActive (false);
		//pakalolo.gameObject.SetActive (true);
		//clash.gameObject.SetActive (false);

		//hunter
		hunt = GetComponent<Animator> ();

	}//start
	
	void Update ()
	{
		high = high - Time.deltaTime * 1;
		SetHighText ();
		SetPointText ();
		//set splat animation
		if (hunt.GetBool("close") == true){
			spray.gameObject.SetActive (true);
		}//if
		//stop animation
		if (hunt.GetBool("close") == false){
			spray.gameObject.SetActive (false);
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
	
	void FixedUpdate ()
	{
		if (high > 50) {
			//godmode
			hunt.SetBool ("fly", true);
			pakalolo.gameObject.SetActive (false);
			clash.gameObject.SetActive (true);
			bloodWater.gameObject.SetActive (true);
			//change song
			//audio.Stop();
			//change skybox
			
			//change water color	
		}//if
		
		if (high < 50) {
			//regularmode
			hunt.SetBool ("fly", false);
			bloodWater.gameObject.SetActive (false);
		}//if
	}//FU
	
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
			high = 100;
			SetHighText ();
		}//if
		//NPC
		if (other.gameObject.CompareTag ("runner") && hunt.GetBool ("fly") == false) {
			high = high - 5;
			SetHighText ();
		}//if
		//NPC
		if (other.gameObject.CompareTag ("sam") && hunt.GetBool ("fly") == false) {
			high = high - 100;
			SetHighText ();
		}//if
		//godmode NPC
		if (other.gameObject.CompareTag ("runner") && hunt.GetBool ("fly") == true 
			|| other.gameObject.CompareTag ("runner") && hunt.GetBool ("close") == true) {
			//trigger splat animation
			spray.gameObject.SetActive (true);
			//trigger hit animation
			hunt.SetBool ("close", true);
			other.gameObject.SetActive (false);
			points = points + 5;
			SetPointText ();
		}//if
		//godmode NPC
		if (other.gameObject.CompareTag ("sam") && hunt.GetBool ("fly") == true 
			|| other.gameObject.CompareTag ("runner") && hunt.GetBool ("close") == true) {
			//trigger splat animation
			spray.gameObject.SetActive (true);
			//trigger hit animation
			hunt.SetBool ("close", true);
			other.gameObject.SetActive (false);
			points = points + 10;
			SetPointText ();
		}//if
		else {
			hunt.SetBool ("close", false);
			spray.gameObject.SetActive (false);
		}
	}//OnTriggerEnter
	
	void SetHighText ()
	{
		highText.text = "Highness: " + high.ToString ();
	}//SetHighText

	void SetPointText ()
	{
		pointText.text = "Killpoints: " + points.ToString ();
	}//SetPointText
	
}//class