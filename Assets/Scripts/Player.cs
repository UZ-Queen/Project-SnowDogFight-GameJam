using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// ?Έν??λ°μ ??
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
        //snowBall.SetForce(InputManager.Horizontal);



        
    }
}
