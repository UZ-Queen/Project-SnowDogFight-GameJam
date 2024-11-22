using JetBrains.Rider.Unity.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{
    [SerializeField] private Transform snowballPosition;
    [SerializeField] private SnowBall snowBall;


    private float offset = 0.8f;
    private bool isRide;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isRide = true;
        }
        if (isRide)
            Ride();
    }

    void Ride()
    {
        transform.position = new Vector3(
            snowballPosition.position.x,
            snowballPosition.position.y + snowBall.transform.localScale.x / 2 + offset,
            transform.position.z);
    }
}