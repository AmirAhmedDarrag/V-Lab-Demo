using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextTyper : MonoBehaviour
{

	public float letterPause = 0.2f;
	public Text gText;
	public string _text;
	public static string _TypeText;
	bool Complete;
	// Use this for initialization


	void Update ()
	{
        if (panelController.disText) {
            StartCoroutine("TypeText");
            panelController.disText = false;
        }
		
		if (gText.cachedTextGenerator.lineCount == 7) {
			string[] str = _TypeText.Split (new string[] { " " }, System.StringSplitOptions.None);
			_TypeText = "";
			_TypeText = str [str.Length - 1];
		
		}

	}

	IEnumerator TypeText ()
	{
		foreach (char letter in _text.ToCharArray()) {
			_TypeText += letter;
			gText.text = _TypeText;
			yield return new WaitForSeconds (letterPause);
		}      
	}
}