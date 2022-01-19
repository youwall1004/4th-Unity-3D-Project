﻿using UnityEngine;
using System.Collections;

public class ThirdPersonCam : MonoBehaviour
{

    //추적할 대상
    public Transform target;
    //카메라와의 거리   
    public float dist = 4f;

    //카메라 회전 속도
    public float xSpeed = 220.0f;
    public float ySpeed = 100.0f;

    //카메라 초기 위치
    private float x = 0.0f;
    private float y = 0.0f;

    //y값 제한
    public float yMinLimit = -20f;
    public float yMaxLimit = 80f;

    //앵글의 최소,최대 제한
    float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
            angle += 360;
        if (angle > 360)
            angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }

    void Start()
    {
        //커서 숨기기"//"를 지우세요
        Cursor.lockState = CursorLockMode.Locked;
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;

     }

    void Update()
    {
        if (target)
        {
            //마우스 스크롤과의 거리계산
            dist -= 1 * Input.mouseScrollDelta.y;

            //마우스 스크롤했을경우 카메라 거리의 Min과Max
            if (dist < 0.5)
            {
                dist = 1;

            }

            if (dist >= 9)
            {
                dist = 9;
            }

            //카메라 회전속도 계산
            x += Input.GetAxis("Mouse X") * xSpeed * 0.015f;
            y -= Input.GetAxis("Mouse Y") * ySpeed * 0.015f;

            //앵글값 정하기
            //y값의 Min과 MaX 없애면 y값이 360도 계속 돎
            //x값은 계속 돌고 y값만 제한
            y = ClampAngle(y, yMinLimit, yMaxLimit);

            //카메라 위치 변화 계산
            Quaternion rotation = Quaternion.Euler(y, x, 0);
            Vector3 position = rotation * new Vector3(0, 0.0f, -dist) + target.position + new Vector3(0.0f, 0, 0.0f);

            transform.rotation = rotation;
            transform.position = position;
        }

    }
}