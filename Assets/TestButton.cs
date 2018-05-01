using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestButton: MonoBehaviour
{
	public GameObject hhh;
	bool oo = false;
	public GameObject _Temp, _FPC, _Camera;
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.JoystickButton7)) {
			oo = true;
			_Camera.transform.parent = _Temp.transform;
			_FPC.SetActive (false);
		}
		if (oo) {
			float horizontalMove = Input.GetAxisRaw ("Horizontal");
			float vertiaclMove = Input.GetAxisRaw ("Vertical");
			Vector3 moveDirection = (horizontalMove * transform.right + vertiaclMove * transform.forward).normalized;
			if (horizontalMove != 0 && vertiaclMove != 0) {
				hhh.transform.Rotate (horizontalMove, 0, vertiaclMove);
			} else {
				hhh.transform.Rotate (vertiaclMove, horizontalMove, 0);
			}
			
		}



	}
}
