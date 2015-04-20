/*

if temp.z == 130
{
	regeneragte/spawn NPCs
	randomize location/appearance
}

if temp.z <= -9
{
	destroy all NPCs
}
 attach this to ground
*/

using UnityEngine;
using System.Collections;


public class runGen : MonoBehaviour
{
	//Bounds.size
	public GameObject runner;
	public float runSpeed ;

	void Start()
	{
		runner = GameObject.Find("runner");
	}
	
	// Scrolling speed
	public Vector3 speed = new Vector3(2, 2, 2);
	
	public float scrollSpeed = 1000.0f;
	
	// Moving direction
	public Vector3 direction = new Vector3(-2, 0, 0);
	
	// Movement should be applied to camera
	public bool isLinkedToCamera = true;
	
	void shift()
	{
		Vector3 temp = transform.position;
		
		//for ground0
		//if ()
		//- decrement z of prefab by size of the prefab
		temp.z = temp.z - 5 * Time.deltaTime;
		transform.position = temp;
		//- if z < some lower bound, bump it back up to the top
		if (temp.z <= -9)
		{
			temp.z = 130;
			transform.position = temp;
		}
	}
	
	void Update ()
	{
		GetComponent<Rigidbody>().AddForce(Vector3.forward * runSpeed);
		shift();
	}//update
}//class