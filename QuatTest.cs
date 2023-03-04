using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuatTest : MonoBehaviour {

    public int type = 1;
    // Use this for initialization

    float counter = 0;
    Quaternion q1 = Quaternion.Euler(90,0,0);
    Quaternion q2 = Quaternion.Euler(0,0,30);

	void Start () {
        Quaternion q;

        if (type == 1)
        {
            q = q1 * q2;
            transform.rotation = q;
        }
        else if (type == 2)
        {
            //q = q2 * q1;
            //transform.rotation = q;
        }
        else if (type == 3)
        {
            //transform.rotation = q1 * transform.rotation;
            //transform.rotation = q2 * transform.rotation;
        }
        else if (type == 4)
        {
            transform.rotation = q2 * q1;
            //Vector3 forward = transform.forward;
            //forward = (q2 * q1) * forward;
            //transform.forward = forward;

            //Quaternion.LookRotation(transform.forward);
        }

        Debug.Log("TYPE:"+type+"  "+transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
        counter += 0.01f;
        Quaternion q = q1 * q2;
        if (type == 2)
        {
            if (counter <= 1)
            {
                transform.rotation = Quaternion.Slerp(Quaternion.identity, q1, counter);
                Quaternion.Euler(0, 0, 0);
            }
            else if (counter <= 2)
            {
                transform.rotation = Quaternion.Slerp(q1, q, counter-1);
            }
        }
        if (type == 3)
        {
            transform.rotation = Quaternion.Slerp(Quaternion.identity, q, counter/2.0f);
        }

    }
}
