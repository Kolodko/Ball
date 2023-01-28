using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public BallController Ball;
    public bool StartCamera;

    //Камера следит за игроком
    private void LateUpdate()
    {
        if (StartCamera)
        {
            Vector3 temp = transform.position;
            temp.x = Ball.transform.position.x;

            transform.position = temp;
        }
    }
}