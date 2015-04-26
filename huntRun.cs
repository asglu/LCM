using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class huntRun : MonoBehaviour
{
	public KeyCode left = KeyCode.LeftArrow;
	public KeyCode right = KeyCode.RightArrow;
	
	public float leftSpeed = 500;
	public float rightSpeed = 500;
	
	private float rightX = 6.23f; 
	private float leftX = -6.48f;
	
	private float increment;

	public Text highText;

	private static int high;

	
	void start()
	{
		high = 100;
		SetHighText ();

		float h = -Input.GetAxis ("Horizontal");
		transform.Translate (h, 0, 0);
		
		Vector3 tmpPos = transform.position;
		//restrict Hunter from moving beyond X curb boundaries
		tmpPos.x = Mathf.Clamp(tmpPos.x, rightX, leftX);
		transform.position = tmpPos;

	}//start
	
	void Update ()
	{
		//high = high - Time.deltaTime;
		//movement
		if (Input.GetKey (KeyCode.LeftArrow)) 
		{
			increment += (leftSpeed / 100) * Time.deltaTime;
			transform.position = Vector3.Lerp(transform.position, transform.position + Vector3.left, increment);
		}//if
		
		if (Input.GetKey (KeyCode.RightArrow))
		{
			increment += (rightSpeed / 100) * Time.deltaTime;
			transform.position = Vector3.Lerp(transform.position, transform.position + Vector3.right, increment);
		}//if
	}//update

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("drugs"))
		{
			other.gameObject.SetActive(false);
			high = high + 5;
			SetHighText ();
		}//if

		else if (other.gameObject.CompareTag("club"))
		{
			other.gameObject.SetActive(false);
			high = 100;
			SetHighText ();
		}//if
	}//OnTriggerEnter

	void SetHighText ()
	{
		highText.text = "Highness: " + high.ToString ();

		//if (high >= 100)
		//{
			//winText.text = "LONO MODE!!";
		//}//if
	}//SetHighText

}//class