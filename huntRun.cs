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

	private static float high;


	void start()
	{
		high = 100;

		float h = -Input.GetAxis ("Horizontal");
		transform.Translate (h, 0, 0);
	}//start
	
	void Update ()
	{
		high = high - Time.deltaTime * 1;
		SetHighText ();

		//restricts X movement
		if (transform.position.x > rightX)
		{
			transform.position = new Vector3(rightX, transform.position.y, transform.position.z);
		}//if
		else if (transform.position.x < leftX)
		{
			transform.position = new Vector3(leftX, transform.position.y, transform.position.z);
	}//else if

		//movement
		if(Input.GetKey (KeyCode.LeftArrow)) 
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
			}//else if
				else if (other.gameObject.CompareTag("runner"))
				{
					high = high - 5;
					SetHighText ();
				}//else if
					else if (other.gameObject.CompareTag("sam"))
					{
						high = high - 100;
						SetHighText ();
					}//else if
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