using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurningAround : MonoBehaviour
{
    public Transform pivotObject;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        //transform.RotateAround(pivotObject.position, Vector3.down, speed * Time.deltaTime);
    }
}
