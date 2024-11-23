using JetBrains.Rider.Unity.Editor;
using System.Collections;
using System.Collections.Generic;
// using System.Numerics;
using UnityEngine;

public class Person : MonoBehaviour
{
    [SerializeField] private Transform tiltPoint;
    [SerializeField] private Transform snowballPosition;
    [SerializeField] private SnowBall snowBall;
    [SerializeField] private float tiltSpeed;

    [SerializeField] private Vector2 offset = Vector2.up;
    private bool isRide;

    void Update()
    {
        if (Input.GetKeyDown(InputManager.Interaction))
        {
            ToggleRiding();
        }
        if (isRide)
        {
            Ride();
            Tilt(); 
        }
    }

    void ToggleRiding(){
        transform.position += (Vector3)offset*(isRide ? -1 : 1);
        isRide ^= true;
    }

    void Ride()
    {

        tiltPoint.position = new Vector3(
            snowballPosition.position.x + (snowBall.transform.localScale.x / 2) * Mathf.Cos((transform.parent.rotation.eulerAngles.z + 90) * Mathf.Deg2Rad),
            snowballPosition.position.y + (snowBall.transform.localScale.x / 2) * Mathf.Sin((transform.parent.rotation.eulerAngles.z + 90) * Mathf.Deg2Rad),
            transform.position.z);
 
    }


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