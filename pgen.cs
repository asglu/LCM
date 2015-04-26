
using UnityEngine;
using System.Collections;


public class pgen : MonoBehaviour
{
	
	void shift()
	{
		Vector3 temp = transform.position;
		
		//for ground0
		//if ()
		//- decrement z of prefab by size of the prefab
		temp.z = temp.z - 40 * Time.deltaTime;
		transform.position = temp;
		//- if z < some lower bound, bump it back up to the top
		if (temp.z <= 27)
		{
			temp.z = 825;
			transform.position = temp;
		}//if
	}//shift

	void Update ()
	{
		shift();
	}//update
}//class
