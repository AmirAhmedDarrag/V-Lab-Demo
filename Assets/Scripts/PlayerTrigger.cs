using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour {
    public GameObject []_Door;
    public bool _DoorOpen;

    void Update()
    {

        /*if (_DoorOpen)
        {
            if (_Door[0].transform.position.x > 1.2f)
                _Door[0].transform.Translate((-1.5f) * Time.deltaTime, 0, 0);
            if (_Door[1].transform.position.x < -2.3f)
                _Door[1].transform.Translate(1.5f * Time.deltaTime, 0, 0);

        }*/
    }

/*    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hello");
        if (other.gameObject.name == "Close") {
            Debug.Log("Hello");
            _DoorOpen = true;
        }
    }*/
}
