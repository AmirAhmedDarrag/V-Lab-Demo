using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {
    /* static GameObject heart_pos;
     static GameObject lungs_pos;
     static GameObject stomach_pos;
     static GameObject liver_pos;*/
    public static bool ResetAll;
    public GameObject skillton;
    public GameObject[] organs;
    Vector3 old_pos_heart;
    Vector3 old_pos_lung;
    Vector3 old_pos_liver;
    Vector3 old_pos_stomach;
    Vector3 new_pos_heart;
    Vector3 new_pos_lungs;
    Vector3 new_pos_liver;
    Vector3 new_pos_stomach;
    public GameObject[] Triggered; 
    // Use this for initialization
    void Start () {
        old_pos_heart = organs[0].transform.position;
        old_pos_lung = organs[1].transform.position;
        old_pos_stomach = organs[2].transform.position;
        old_pos_liver = organs[3].transform.position;
        new_pos_lungs.z = 22.0f;
        new_pos_lungs.y = old_pos_lung.y;
        new_pos_lungs.x = -1.5f;
        new_pos_heart.z = 22.0f;
        new_pos_heart.x = -0.058f;
        new_pos_heart.y = old_pos_heart.y;
        new_pos_stomach.z = 22.0f;
        new_pos_stomach.x = 0.45f;
        new_pos_stomach.y = old_pos_stomach.y;
        new_pos_liver.z = 22f;
        new_pos_liver.x = -0.49f;
        new_pos_liver.y = old_pos_liver.y;
    }
	
	// Update is called once per frame
	void Update () {
      
        //Reset All
        if (ResetAll)
        {
            skillton.SetActive(true);
            skillton.GetComponent<Collider>().enabled = true;
            organs[0].transform.position = old_pos_heart;
            organs[1].transform.position = old_pos_lung;
            organs[2].transform.position = old_pos_stomach;
            organs[3].transform.position = old_pos_liver;
            for (int i = 0; i < 4; i++) {
                organs[i].SetActive(true);
                Triggered[i].SetActive(true);
            }
            Debug.Log("hello");
            ResetAll = false;

        }
	}
    public void onSkeleton() {
        organs[0].transform.position = new_pos_heart;
        organs[1].transform.position = new_pos_lungs;
        organs[2].transform.position = new_pos_stomach;
        organs[3].transform.position = new_pos_liver;
        skillton.GetComponent<Collider>().enabled = false;
            skillton.SetActive(false);

    }
    public void organ_back(int index)
    {
        for (int i = 0; i < 4; i++)
        {
            Triggered[i].SetActive(false);
            if (i == index)
            {
                if (index == 0)
                {
                    organs[0].transform.position = old_pos_heart;
                }
                else if (index == 1)
                {
                    organs[1].transform.position = old_pos_lung;
                }
                else if (index == 2)
                {
                    organs[2].transform.position = old_pos_stomach;
                    
                }
                else
                    organs[3].transform.position = old_pos_liver;

            }
            else
            {
                Debug.Log(i);
                organs[i].SetActive(false);
            }
            skillton.SetActive(true);
            
        }
    }
}
