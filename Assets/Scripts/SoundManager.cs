using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static bool soundDisplay;
    public static bool soundPause;
    public AudioClip[] _TextSounds;
    public AudioSource _SrcSound;


    // Update is called once per frame
    void Update()
    {

        if (OrgansManager._OrgansIndex == -1 || TextManager.NPSound)
        {
            _SrcSound.Stop();
            TextManager.NPSound = false;
        }

        //sound Display
        if (soundDisplay) {
            if (OrgansManager._moreText == 1)
            {
                _SrcSound.clip = _TextSounds[OrgansManager._soundIndex + TextManager.nav];
            }
            else
            {
                _SrcSound.clip = _TextSounds[OrgansManager._soundIndex];
            }
            _SrcSound.Play();

            soundDisplay = false;
        }

        //sound Pause
        if (soundPause) {
            _SrcSound.Pause();

            soundPause = false;
        }
    }
 
}
