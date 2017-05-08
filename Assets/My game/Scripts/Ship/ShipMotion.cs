using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMotion : MonoBehaviour
{



	void Update ()
	{
		float move = Input.GetAxis ("Vertical");
		float rotate = Input.GetAxis ("Horizontal");
		transform.Translate (Vector3.right * move * 2f * Time.deltaTime); // rigth (left)
		//transform.position = new Vector3 (transform.position.x, transform.position.y,
			//transform.position.z - move * 2f * Time.deltaTime);
		transform.eulerAngles = new Vector3 (transform.eulerAngles.x,
			transform.eulerAngles.y + rotate * 25f * Time.deltaTime, transform.eulerAngles.z); // + (-)
			
	}



}
