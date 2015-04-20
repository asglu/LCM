using UnityEngine;
using System.Collections;

public class groundScroll : MonoBehaviour
{
	// Scrolling speed
	public Vector3 speed = new Vector3(0, 0, 1);

	// Moving direction
	public Vector3 direction = new Vector3(-1, 0, 0);
	
	// Movement should be applied to camera
	public bool isLinkedToCamera = false;

	void shift()
	{
		Vector3 temp = transform.position;
		//for ground0
		//if ()
		//- decrement z of prefab by size of the prefab
		temp.z = temp.z - 28 * Time.deltaTime;
		transform.position = temp;
		//- if z < some lower bound, bump it back up to the top
		if (temp.z <= 2.8)
		{
			temp.z = 140;
			transform.position = temp;
		}//if
	}//shift

	void Update ()
	{
		shift();
	}//update

}//class