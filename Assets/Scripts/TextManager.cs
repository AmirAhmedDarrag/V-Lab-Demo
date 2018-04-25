using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
	public RectTransform[] _Panel;
	public Button _Next, _Previous;
	public static Vector3 desiredMenuPosition;
	public static bool NPSound;
	public static int nav;
	private int c;


	void Awake ()
	{
		NPSound = false;
		//initialize 
		nav = 0;
		c = 0;
	}
		
	// Update is called once per frame
	void Update ()
	{
        
		// if no Organs selected
		if (OrgansManager._OrgansIndex == -1) {
			//call SetTextFalse
			SetTextFalse ();
		}
		// if Organs selected 
		else if (OrgansManager._OrgansIndex >= 0) {
			TextDisplay ();
		}

        
	}

	//set All Text false
	public void SetTextFalse ()
	{
		for (int i = 0; i < _Panel.Length; i++) {
			_Panel [i].gameObject.SetActive (false);
		}
	}

	//Display Target Text
	public void TextDisplay ()
	{
		for (int i = 0; i < _Panel.Length; i++) {
			if (i == OrgansManager._OrgansIndex) {
				_Panel [i].gameObject.SetActive (true);
			} else {
				_Panel [i].gameObject.SetActive (false);
			}
		}
		if (OrgansManager._moreText == 1) {
			_Next.gameObject.SetActive (true);
			_Previous.gameObject.SetActive (true);
			_Panel [OrgansManager._OrgansIndex].anchoredPosition3D = Vector3.Lerp (_Panel [OrgansManager._OrgansIndex].anchoredPosition3D, desiredMenuPosition, 0.1f);
			HideText (nav);
		} else {
			_Next.gameObject.SetActive (false);
			_Previous.gameObject.SetActive (false);
		}
	}
	// Next Button Clicked
	public void NextClicked ()
	{
		
		if (nav < c - 1) {
			nav++;
			desiredMenuPosition = Vector3.left * 883 * nav;
			NPSound = true;
		}

	}

	// Previous Button Clicked
	public void PrevClicked ()
	{
        
		if (nav > 0) {
			nav--; 
			desiredMenuPosition = Vector3.left * 883 * nav;
			NPSound = true;
		}
	}

	//Hide Text
	private void HideText (int j)
	{
		c = 0;
		while (_Panel [OrgansManager._OrgansIndex].GetChild (c).name != "GameObject") {
			if (c == j) {
				_Panel [OrgansManager._OrgansIndex].GetChild (c).gameObject.SetActive (true);
			} else {
				_Panel [OrgansManager._OrgansIndex].GetChild (c).gameObject.SetActive (false);
			}
			c++;
		}

	}



}
