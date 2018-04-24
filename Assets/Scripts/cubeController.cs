using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeController : MonoBehaviour {

    public GameObject cube;

    public void rotate(float newvalue)
    {

        Vector3 pos = cube.transform.position;
        pos.y = newvalue;

        
        cube.transform.Rotate(0,pos.y,0);

    }
    public void scale (float newvalue)
    {

        Vector3 pos = transform.localScale;

        pos.x = newvalue;
        pos.y = newvalue;
        pos.z = newvalue;


        cube.transform.localScale = pos;



    }
}
