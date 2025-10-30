/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eyeTracker : MonoBehaviour
{
    GameObject myTarget;
    // Start is called before the first frame update
    void Start()
    {
        myTarget = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //calculating the distance from eyeball and player (this is in world space)
        Vector3 delta = myTarget.transform.position - transform.position;

        //calculating the distance from eyeball to player
        Debug.DrawRay(transform.position, delta, Color.yellow);

        //translate the local up vector of our eyeball into world space coordinates
        Vector3 localUp = transform.TransformDirection(Vector3.up);
        Vector3 localForward = transform.TransformDirection(Vector3.forward);

        //debug showing the up vector of our eyeball into world space coordinates
        Debug.DrawRay(transform.position, localUp, Color.cyan);
        Debug.DrawRay(transform.position, localForward, Color.red);

        //angleData find the angle between two vectors, in this case
        //the local up of the eyeball (pupil) and the vector from player to eyeball
        float angleData = Vector3.Angle(delta, localUp);
        Debug.Log("current amgle: " + angleData);

        //locate by difference
        if (angleData >.5)
        {
           transform.Rotate(localForward, angleData);
        }
        

    }
}*/
