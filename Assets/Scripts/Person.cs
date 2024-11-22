using JetBrains.Rider.Unity.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{
    [SerializeField] private Transform tiltPoint;
    [SerializeField] private Transform snowballPosition;
    [SerializeField] private SnowBall snowBall;
    [SerializeField] private float tiltSpeed;

    private bool isRide;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isRide = true;
        }
        if (isRide)
        {
            Ride();
        }
        Tilt();
    }

    void Ride()
    {

        tiltPoint.position = new Vector3(
            snowballPosition.position.x + (snowBall.transform.localScale.x / 2) * Mathf.Cos((transform.parent.rotation.eulerAngles.z + 90) * Mathf.Deg2Rad),
            snowballPosition.position.y + (snowBall.transform.localScale.x / 2) * Mathf.Sin((transform.parent.rotation.eulerAngles.z + 90) * Mathf.Deg2Rad),
            transform.position.z);
 
    }


    // 기울이기
    void Tilt()
    { 
        if (Input.GetKey(KeyCode.Q))
        {
            tiltPoint.RotateAround(tiltPoint.position, Vector3.forward, tiltSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.E))
        {
            tiltPoint.RotateAround(tiltPoint.position, Vector3.forward, -tiltSpeed * Time.deltaTime);
        }
    }
}