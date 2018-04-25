using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

	public AudioClip[] _TextSounds;
	public AudioSource _SrcSound;


	// Update is called once per frame
	void Update ()
	{

		if (OrgansManager._OrgansIndex == -1 || TextManager.NPSound) {
			_SrcSound.Stop ();
			TextManager.NPSound = false;
		}
	}
	// On Display Sound Clicked
	public void OnSoundDisplay ()
	{
		if (OrgansManager._moreText == 1) {
			_SrcSound.clip = _TextSounds [OrgansManager._soundIndex + TextManager.nav];
		} else {
			_SrcSound.clip = _TextSounds [OrgansManager._soundIndex];
		}
		_SrcSound.Play ();
	}

	// On pause Sound Clicked

	public void OnSoundPause ()
	{
		_SrcSound.Pause ();
	}

}
