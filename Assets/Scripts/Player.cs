using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// ?�풋??받을 ??
/// </summary>
[RequireComponent(typeof(SnowBall))]
public class Player : MonoBehaviour
{
    SnowBall snowBall;
    Person person;


    private void Awake() {
        snowBall = gameObject.GetComponentInChildren<SnowBall>();
        person = GetComponentInChildren<Person>();
    }

    void Start()
    {
        
    }
    void Update()
    {
        snowBall.SetForce(InputManager.Horizontal);



        
    }
}
