using UnityEngine;
using System.Collections;

public class groundScroll : MonoBehaviour
{
	// Movement should be applied to camera
	public bool isLinkedToCamera = false;

	public static int high;

	void shift()
	{
		Vector3 temp = transform.position;

		//- decrement z of prefab by size of the prefab
		temp.z = temp.z - 30 * Time.deltaTime;
		transform.position = temp;
		//- if z < ground object lower bound, bump it back up to the top
		if (temp.z <= 27)
		{
			temp.z = 825.9f;
			transform.position = temp;
			//reset all pickups
			reUp ();
		}//if
	}//shift

	void Update ()
	{
		shift();

	}//Update

	//resets all pickups
	void reUp()
	{
		if (gameObject.CompareTag("drugs"))
		{
			gameObject.SetActive(true);
		}//if
	}//reUp

}//class