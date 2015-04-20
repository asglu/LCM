
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
		temp.z = temp.z - 20 * Time.deltaTime;
		transform.position = temp;
		//- if z < some lower bound, bump it back up to the top
		if (temp.z <= 4.964286)
		{
			temp.z = 140;
			transform.position = temp;
		}
	}
	
	void Update ()
	{
		//rotate item
		transform.Rotate(new Vector3(0, 45,0)* 3);
		shift();
	}//update
}//class
