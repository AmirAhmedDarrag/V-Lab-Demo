using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainControl : MonoBehaviour {
    public GameObject _menu,_FPC,_Camera;
    public GameObject[]_Door;
    public bool _DoorOpen;
	// Use this for initialization
	void Start () {
        _FPC.SetActive(false);
        _DoorOpen = false;
	}
	
	// Update is called once per frame
	void Update () {
       if (_DoorOpen) {
             if(_Door[0].transform.position.x < 5.2f)
               _Door[0].transform.Translate(1.5f * Time.deltaTime,0,0);

             if (_Door[1].transform.position.x > -5.5f)
                 _Door[1].transform.Translate(1.5f * Time.deltaTime, 0, 0);
        }
	}

    public void OnModeClicked() {
        _Camera.transform.parent = _FPC.transform;
        _FPC.SetActive(true);
        _menu.SetActive(false);
        _DoorOpen = true;

    }
    public void LoadScene(string SceneName) {
        SceneManager.LoadScene(SceneName);
    }
    public void ResetAll() {
        OrgansManager.resetAll = true;
        AnimationController.ResetAll = true;
    }

    public void NextClicked()
    {
        TextManager.nextClicked = true;
    }
    public void PrevClicked()
    {
        TextManager.prevClicked = true;
    }

    public void SoundDiplay() {
        SoundManager.soundDisplay = true;
    }

    public void SoundPause()
    {
        SoundManager.soundPause = true;
    }
}
