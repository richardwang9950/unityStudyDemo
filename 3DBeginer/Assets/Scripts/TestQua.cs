using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestQua : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 vr = new Vector3(1, 0, 0);
        Quaternion q1 = Quaternion.LookRotation(vr);
        transform.rotation = q1;

        //Vector3 vforwardp = new Vector3(0, 0, 1);
        //Quaternion q2 = Quaternion.FromToRotation(vforwardp, vr);

    }
}
