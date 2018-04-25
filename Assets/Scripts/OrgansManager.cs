using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrgansManager : MonoBehaviour
{

	public static int _OrgansIndex;
	public static int _moreText;
	public static int _soundIndex;
	public GameObject[] _Organs;

	void Awake ()
	{

		//initialize 
		_OrgansIndex = -1;
		_moreText = 0;
	}

	//Organs Trigger(Action)
	public void OnOrgansTrigger (int index)
	{
		//set All Organs by false except the Trigger Organs
		for (int i = 0; i < _Organs.Length; i++) {
			if (i == index) {
				_Organs [i].SetActive (true);
                
			} else {
				_Organs [i].SetActive (false);
			}
			_OrgansIndex = index;
		}
			
	}

	public void OnOrganstouch (int MoreText)
	{
		_moreText = MoreText;
        
	}

	// Determine Sound Display

	public void OnSoundDetermine (int SIndex)
	{
		_soundIndex = SIndex;
	}
	//Reset All
	public void ResetAll ()
	{
		//set All Organs by true
		for (int i = 0; i < _Organs.Length; i++) {
			
			_Organs [i].SetActive (true);
		}

		// set shared Index by -1
		_OrgansIndex = -1;

		// set boolean Index by false 
		_moreText = 0;

		//Reset nav
		TextManager.desiredMenuPosition = Vector3.zero;
		TextManager.nav = 0;

		//reset Sound
		TextManager.NPSound = false;

	}
}
