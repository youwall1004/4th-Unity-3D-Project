using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    //따라다닐 대상  
    public GameObject target;

    public float offsetX;
    public float offsetY;
    public float offsetZ;

    public float delayTime;
    void Update()
    {
        Vector3 FixedPos = new Vector3(target.transform.position.x + offsetX,
            target.transform.position.y + offsetY,
            target.transform.position.z + offsetZ);
        //transform.position = Vector3.Lerp(transform.position, FixedPos, Time.deltaTime * delayTime);
        transform.position = FixedPos;
    }
}
