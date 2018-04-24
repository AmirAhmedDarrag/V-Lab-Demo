using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
	public RectTransform[] _Panel;
	public Button _Next, _Previous;
	private Vector3 desiredMenuPosition;
	private int nav;
    
	void Awake ()
	{
        
		//initialize 
		nav = 0;
       
	}

	void Start ()
	{
        
        //HideText(nav);
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
            
            _Panel[OrgansManager._OrgansIndex].anchoredPosition3D = Vector3.Lerp(_Panel[OrgansManager._OrgansIndex].anchoredPosition3D, desiredMenuPosition, 0.1f);
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
                Debug.Log(OrgansManager._OrgansIndex);
				_Panel [OrgansManager._OrgansIndex].gameObject.SetActive (true);
			} else {
				_Panel [OrgansManager._OrgansIndex].gameObject.SetActive (false);
			}
		}
		if (OrgansManager._moreText == 1) {
			_Next.gameObject.SetActive (true);
			_Previous.gameObject.SetActive (true);
		} else {
			_Next.gameObject.SetActive (false);
			_Previous.gameObject.SetActive (false);
		}
	}
	// Next Button Clicked
	public void NextClicked ()
	{
		nav++;
		desiredMenuPosition = Vector3.left * 883 * nav;
        //HideText(nav);
	}

	// Previous Button Clicked
	public void PrevClicked ()
	{
        
		if (nav > 0) {
			nav--; 
			desiredMenuPosition = Vector3.left * 883 * nav;
		//	HideText (nav);
		}
	}

	//Hide Text
	/*private void HideText (int j)
	{
        _Panel[0].GetChild(0).;
	}*/

}
