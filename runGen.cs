using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class runGen : MonoBehaviour
{
	public GameObject runner;
	public float runSpeed ;

	private static int high;

	void Start ()
	{
		runner = GameObject.Find ("runner");

	}//start
	
	// Movement should be applied to camera
	public bool isLinkedToCamera = true;
	
	void shift ()
	{
		Vector3 temp = transform.position;

		temp.z = temp.z - 5 * Time.deltaTime;
		transform.position = temp;

		if (temp.z <= -2) {
			temp.z = 826;
			transform.position = temp;
		}//if
	}//shift
	
	void Update ()
	{
		GetComponent<Rigidbody> ().AddForce (Vector3.forward * runSpeed);
		shift ();
	}//update

}//class