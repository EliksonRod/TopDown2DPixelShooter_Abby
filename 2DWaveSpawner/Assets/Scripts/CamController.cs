using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    void Start()
    {
        //GetComponent<Camera>().orthographicSize = (Screen.height / 16f / 2f);
    }


    /*public CamHelper2D camHelper;
    public float moveSpeed = 0.1f;

    Vector3 randomPos = Vector3.zero;

    void Update()
    {
        Vector3 moveDir = (randomPos - camHelper.GetCameraPos()).normalized;
        camHelper.Move(moveDir * moveSpeed * Time.deltaTime);

    }*/
}
