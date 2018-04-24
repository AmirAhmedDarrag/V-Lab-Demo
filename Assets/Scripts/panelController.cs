using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class panelController : MonoBehaviour {

    public GameObject [] Hide;
    public GameObject panel;
    public float waitSound;
    public AudioClip TextSpeech;
    public AudioSource Src;
     int counter;
     public static bool disText;

     void Start()
     {
         Src.clip = TextSpeech;

     }
    public void HideAndShowPanel(int index)
    {
        counter++;

        if (counter % 2 == 1)
        {
            panel.gameObject.SetActive(true);
            disText = true;
            StartCoroutine("SoundWaitting");
            for (int i = 0; i < Hide.Length; i++) {
                if(i!=index)
                  Hide[i].SetActive(false);
            }
        }
        else
        {
            Src.Stop();
            TextTyper._TypeText = "";
            disText = false;
            panel.gameObject.SetActive(false);
            for (int i = 0; i < Hide.Length; i++)
            {
                if(i!=index)
                   Hide[i].SetActive(true);
            }
        }
    }
    IEnumerator SoundWaitting()
    {
        yield return new WaitForSeconds(waitSound);
        Src.Play();
    }
}
