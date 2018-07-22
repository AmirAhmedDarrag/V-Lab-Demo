using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrgansManager : MonoBehaviour
{
    public bool OrgansTrigger;
    public static int _OrgansIndex;
    public static int _moreText;
    public static int _soundIndex;
    public static bool resetAll;
    private Quaternion Org_Rotation;
    public GameObject[] _Organs;
    Vector3 new_scale, org_scale;
    float value;
    private int _RotationNum;
    public GameObject _Temp, _FPC, _Camera;

    void Awake()
    {
        OrgansTrigger = false;
        //initialize 
        _OrgansIndex = -1;
        _moreText = 0;
        _RotationNum = 0;
    }

    void Update()
    {
        if (OrgansTrigger)
        {
            if (Input.GetKeyDown(KeyCode.JoystickButton1))
            {
                value = 0.1f;
                if ((new_scale.x < org_scale.x + 1.0f))
                    scale(value);
            }
            else if (Input.GetKeyDown(KeyCode.JoystickButton3))
            {
                value = -0.1f;
                if ((new_scale.x > org_scale.x + 0.2f))
                    scale(value);
            }
            if (Input.GetKeyDown(KeyCode.JoystickButton7))
            {
                _RotationNum++;
                if (_RotationNum % 2 != 0)
                {
                    _Camera.transform.parent = _Temp.transform;
                    _FPC.SetActive(false);
                }
                else
                {
                    _Camera.transform.parent = _FPC.transform;
                    _FPC.SetActive(true);
                }
            }

            if (_RotationNum % 2 != 0)
            {
                float horizontalMove = Input.GetAxisRaw("Horizontal");
                float vertiaclMove = Input.GetAxisRaw("Vertical");

                if (horizontalMove != 0 && vertiaclMove != 0)
                {
                    //Debug.Log ("kk");
                    _Organs[_OrgansIndex].transform.Rotate(horizontalMove, 0, vertiaclMove);
                }
                else
                {
                    //Debug.Log ("ssss");
                    _Organs[_OrgansIndex].transform.Rotate(vertiaclMove, horizontalMove, 0);
                }
            }
        }

        // resetAll
        if (resetAll) {
            //set All Organs by true
            for (int i = 0; i < _Organs.Length; i++)
            {

                _Organs[i].SetActive(true);
            }
            _Organs[_OrgansIndex].transform.localScale = org_scale;
            _Organs[_OrgansIndex].transform.rotation = Org_Rotation;
            // set shared Index by -1
            _OrgansIndex = -1;

            // set boolean Index by false 
            _moreText = 0;

            //Reset nav
            TextManager.desiredMenuPosition = Vector3.zero;
            TextManager.nav = 0;

            //reset Sound
            TextManager.NPSound = false;

            OrgansTrigger = false;

            resetAll = false;
        }


    }
    //Organs Trigger(Action)
    public void OnOrgansTrigger(int index)
    {
        OrgansTrigger = true;
        //set All Organs by false except the Trigger Organs
        for (int i = 0; i < _Organs.Length; i++)
        {
            if (i == index)
            {
                _Organs[i].SetActive(true);

            }
            else
            {
                _Organs[i].SetActive(false);
            }
        }
        _OrgansIndex = index;
        org_scale = _Organs[_OrgansIndex].transform.localScale;
        Org_Rotation = _Organs[_OrgansIndex].transform.rotation;
    }

    public void OnOrganstouch(int MoreText)
    {
        _moreText = MoreText;

    }

    // Determine Sound Display

    public void OnSoundDetermine(int SIndex)
    {
        _soundIndex = SIndex;
    }
   

    public void scale(float value)
    {

        new_scale.x = _Organs[_OrgansIndex].transform.localScale.x + value;
        new_scale.y = _Organs[_OrgansIndex].transform.localScale.y + value;
        new_scale.z = _Organs[_OrgansIndex].transform.localScale.z + value;
        _Organs[_OrgansIndex].transform.localScale = new_scale;

    }
}
