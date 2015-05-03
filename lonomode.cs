using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class lonomode : MonoBehaviour
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
	private int points;
	
	void start ()
	{
		high = 100;
		float h = -Input.GetAxis ("Horizontal");
		transform.Translate (h, 0, 0);
		
	}//start

	void FixedUpdate(){

		while (high < 50) {
			// change scenes
			Application.LoadLevel ("Marathon3");
		}//if
	}
	
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
	
	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.CompareTag ("drugs")) {
			other.gameObject.SetActive (false);
			high = high + 5;
			SetHighText ();
		}//if
		if (other.gameObject.CompareTag ("club")) {
			other.gameObject.SetActive (false);
			high = 100;
			SetHighText ();
		}//if

		if (other.gameObject.CompareTag ("Player")) {
			other.gameObject.SetActive (false);
			points = points + 1;
		}//if

	}//OnTriggerEnter
	
	void SetHighText ()
	{
		highText.text = "Highness: " + high.ToString ();
	}//SetHighText
	
}//class
